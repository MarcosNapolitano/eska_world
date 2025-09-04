
using TMPro;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Menu : UdonSharpBehaviour 
{

    [SerializeField] GameObject Panel1;
    [SerializeField] GameObject Panel2;
    [SerializeField] GameObject Deck;
    [SerializeField] GameObject Mazo;
    [SerializeField] GameObject PuntosNosotros;
    [SerializeField] GameObject PuntosEllos;
    [SerializeField] GameObject Reset;

    [SerializeField] TextMeshProUGUI warning;
    [SerializeField] TextMeshProUGUI titulo;
    [SerializeField] TextMeshProUGUI jugadorActivo;

    [UdonSynced] int playerCount = 0;
    [UdonSynced] int scoreEllos = 0;
    [UdonSynced] int scoreNosotros = 0;
    [UdonSynced] int prevScoreEllos = 0;
    [UdonSynced] int prevScoreNosotros = 0; 

    [UdonSynced] string Ganador;

    [UdonSynced] bool estadoPanel1 = true;
    [UdonSynced] bool estadoPanel2 = false;
    [UdonSynced] bool estadoDeck = false;
    [UdonSynced] bool partidaFinalizada = false;



    public override void OnDeserialization()
    {
        Panel1.SetActive(estadoPanel1);
        Panel2.SetActive(estadoPanel2);
        Deck.SetActive(estadoDeck);

        
        if (partidaFinalizada)
        {
            titulo.text = "Partida finalizada, ganador:";
            jugadorActivo.text = Ganador;
        }

        if(prevScoreEllos < scoreEllos)
        {
            PuntosEllos.transform.GetChild(scoreEllos - 1).gameObject.SetActive(true);
        }
        else
        {
            PuntosEllos.transform.GetChild(scoreEllos).gameObject.SetActive(false);
        }

        if (prevScoreNosotros < scoreNosotros)
        {
            PuntosNosotros.transform.GetChild(scoreNosotros - 1).gameObject.SetActive(true);
        }
        else
        {
            PuntosNosotros.transform.GetChild(scoreNosotros).gameObject.SetActive(false);
        }

        if(scoreNosotros == 0 && scoreEllos == 0)
        {
            for(int i = 0; i < PuntosEllos.transform.childCount; i++)
            {
                PuntosEllos.transform.GetChild(i).gameObject.SetActive(false);
            }

            for (int i = 0; i < PuntosNosotros.transform.childCount; i++)
            {
                PuntosNosotros.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        warning.text = "";

    }

    private void _SelectGameMode()
    {
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        Networking.SetOwner(Networking.LocalPlayer, Deck);
        Networking.SetOwner(Networking.LocalPlayer, Mazo);
        Networking.SetOwner(Networking.LocalPlayer, Reset);


        estadoPanel2 = true;
        estadoPanel1 = false;
        estadoDeck = true;
        Panel1.SetActive(estadoPanel1);
        Panel2.SetActive(estadoPanel2);
        Deck.SetActive(estadoDeck);

        RequestSerialization();
    }

    public void _Select2Players()
    {

        playerCount = 2;
        _SelectGameMode();


    }

    public void _Select4Players()
    {
    
        playerCount = 4;
        _SelectGameMode();

    }

    public void _Select6Players()
    {

        playerCount = 6;
        _SelectGameMode();

    }

    public void _Reset() {

        if (Networking.LocalPlayer != Networking.GetOwner(gameObject))
        {
            warning.text = "Solo " + Networking.GetOwner(gameObject).displayName + " puede reiniciar.";
            return;
        }
        estadoPanel2 = false;
        estadoPanel1 = true;
        estadoDeck = false;
        partidaFinalizada = false;
        Reset.GetComponent<UdonBehaviour>().SendCustomEvent("Reset");

        

        Panel1.SetActive(estadoPanel1);
        Panel2.SetActive(estadoPanel2);
        Deck.SetActive(estadoDeck);

        playerCount = 0;
        scoreEllos = 0;
        scoreNosotros = 0;
        prevScoreEllos = 0;
        prevScoreNosotros = 0;

        for (int i = 0; i < PuntosEllos.transform.childCount; i++)
        {
            PuntosEllos.transform.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < PuntosNosotros.transform.childCount; i++)
        {
            PuntosNosotros.transform.GetChild(i).gameObject.SetActive(false);
        }

        titulo.text = "Partida en curso, ultimo en repartir:";
        jugadorActivo.text = "";
        Ganador = "";

        RequestSerialization();

    }

    public void _sumEllos()
    {
        if (Networking.LocalPlayer != Networking.GetOwner(gameObject)) return;
        if (scoreEllos == 30) return;
        prevScoreEllos = scoreEllos;
        scoreEllos++;
        PuntosEllos.transform.GetChild(scoreEllos-1).gameObject.SetActive(true);

        if (scoreEllos == 30)
        {
            _finalizarPartida("Ellos");
        }

        RequestSerialization();
    }

    public void _restEllos()
    {
        if (Networking.LocalPlayer != Networking.GetOwner(gameObject)) return;
        if (scoreEllos == 0) return;
        prevScoreEllos = scoreEllos;
        scoreEllos--;
        PuntosEllos.transform.GetChild(scoreEllos).gameObject.SetActive(false);
        RequestSerialization();
    }

    public void _sumNosotros()
    {
        if (Networking.LocalPlayer != Networking.GetOwner(gameObject)) return;
        if (scoreNosotros == 30) return;
        prevScoreNosotros = scoreNosotros;
        scoreNosotros++;
        PuntosNosotros.transform.GetChild(scoreNosotros - 1).gameObject.SetActive(true);
        if (scoreNosotros == 30)
        {
            _finalizarPartida("Nosotros");
        }

        RequestSerialization();
    }

    public void _restNosotros()
    {
        if (Networking.LocalPlayer != Networking.GetOwner(gameObject)) return;
        if (scoreNosotros == 0 || scoreNosotros == 30) return;
        prevScoreNosotros = scoreNosotros;
        scoreNosotros--;
        PuntosNosotros.transform.GetChild(scoreNosotros).gameObject.SetActive(false);
        RequestSerialization();
    }

    private void _finalizarPartida(string ganador)
    {
        partidaFinalizada = true;
        Ganador = ganador;
        titulo.text = "Partida finalizada, ganador:";
        jugadorActivo.text = Ganador;

        RequestSerialization();
    }
}
