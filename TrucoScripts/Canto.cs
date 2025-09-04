
using UdonSharp;
using UnityEngine;
using UnityEngine.InputSystem.Composites;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class Canto : UdonSharpBehaviour
{
    [UdonSynced] string canto = "";

    [SerializeField] ParticleSystemRenderer cartel;
    [SerializeField] UdonBehaviour Dealer;

    [SerializeField] Button[] botones = new Button[7];

    [SerializeField] Material[] materiales = new Material[7];

    public override void OnDeserialization()
    {
        _setCartel();
    }
    private void _setCartel()
    {
        cartel.gameObject.SetActive(true);

        switch (canto)
        {
            case "envido":
                cartel.sharedMaterial = materiales[3];
                break;
            case "envido2":
                botones[0].interactable = false;
                cartel.sharedMaterial = materiales[4];
                break;
            case "realenvido":
                botones[0].interactable = false;
                botones[1].interactable = false;
                cartel.sharedMaterial = materiales[5];
                break;
            case "faltaenvido":
                botones[0].interactable = false;
                botones[1].interactable = false;
                botones[2].interactable = false;
                cartel.sharedMaterial = materiales[6];
                break;
            case "truco":
                botones[5].interactable = true;
                cartel.sharedMaterial = materiales[0];
                break;
            case "retruco":
                botones[4].interactable = false;
                botones[6].interactable = true;
                cartel.sharedMaterial = materiales[1];
                break;
            case "vale4":
                botones[5].interactable = false;
                cartel.sharedMaterial = materiales[2];
                break;
            default:
                cartel.gameObject.SetActive(false);
                break;
        }
    }

    private void _setMode(string mode)
    {
        if (Dealer.GetProgramVariable("partidaActiva").Equals(false)) return;

        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        if (canto == mode) canto = "";
        else canto = mode;
        _setCartel();
        RequestSerialization();
    }

    public void _setTruco() { _setMode("truco"); }

    public void _setReTruco() { _setMode("retruco"); }

    public void _setVale4() { _setMode("vale4"); }

    public void _setEnvido() { _setMode("envido"); }

    public void _setEnvido2() { _setMode("envido2"); }

    public void _setRealEnvido() { _setMode("realenvido"); }

    public void _setFaltaEnvido() { _setMode("faltaenvido"); }

    public void resetButtons()
    {
        for (int i = 0; i < botones.Length; i++)
        {
            botones[i].interactable = true;

            if (i == 5 || i == 6) botones[i].interactable = false;
            

        }

    }

}
