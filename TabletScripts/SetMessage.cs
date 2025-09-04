
using TMPro;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SetMessage : UdonSharpBehaviour
{
    [SerializeField] TMP_InputField LocalCartel;
    [SerializeField] SendMessage Mensajero;

    public void _PassMessage()
    {
        Mensajero._SetMessage(LocalCartel.text);

    }
}
