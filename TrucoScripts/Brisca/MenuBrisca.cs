
using TMPro;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MenuBrisca : UdonSharpBehaviour
{

    [SerializeField] GameObject Panel1;
    [SerializeField] GameObject Panel2;
    [SerializeField] GameObject Deck;
    [SerializeField] GameObject Mazo;
    [SerializeField] GameObject Reset;

    [SerializeField] TextMeshProUGUI warning;

    [UdonSynced] int playerCount = 0;
    [UdonSynced] bool estadoPanel1 = true;
    [UdonSynced] bool estadoPanel2 = false;
    [UdonSynced] bool estadoDeck = false;



    public override void OnDeserialization()
    {
        _setEstado();
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

        _setEstado();

        RequestSerialization();
    }

    private void _setEstado()
    {
        Panel1.SetActive(estadoPanel1);
        Panel2.SetActive(estadoPanel2);
        Deck.SetActive(estadoDeck);
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

    public void _Reset()
    {

        if (Networking.LocalPlayer != Networking.GetOwner(gameObject))
        {
            warning.text = "Solo " + Networking.GetOwner(gameObject).displayName + " puede reiniciar.";
            return;
        }

        playerCount = 0;
        estadoPanel2 = false;
        estadoPanel1 = true;
        estadoDeck = false;

        _setEstado();

        Reset.GetComponent<UdonBehaviour>().SendCustomEvent("Reset");

        RequestSerialization();

    }

}

