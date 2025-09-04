
using TMPro;
using UdonSharp;
using UnityEngine;
using UnityEngine.UIElements;
using VRC.SDKBase;
using VRC.Udon;

public class SendMessage : UdonSharpBehaviour
{
    [SerializeField] TextMeshProUGUI Cartel;
    [SerializeField] TextMeshProUGUI Cartel2;
    [SerializeField] GameObject Container;
    [UdonSynced] string Message;
    [UdonSynced] string Sender;


    public override void OnDeserialization()
    {
        _SetCartel();
    }

    public void _SetMessage(string Texto)
    {
        Message = Texto;
        Sender = Networking.LocalPlayer.displayName + " dice:";
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        RequestSerialization();
        _SetCartel();
    }

    public void _SetCartel()
    {
        Container.SetActive(true); 
        Cartel.text = Message;
        Cartel2.text = Sender;
        SendCustomEventDelayedSeconds("_TurnOff", 10);
    }

    public void _TurnOff()
    {
        Container.SetActive(false);
    }


}
