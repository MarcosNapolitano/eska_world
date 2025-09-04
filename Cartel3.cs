
using TMPro;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;

public class Cartel3 : UdonSharpBehaviour
{
    public GameObject[] Carteles = new GameObject[4];
    [UdonSynced] bool State = false;

    public override void OnDeserialization()
    {
        _TurnCarteles();
    }

    public override void Interact()
    {
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        State = !State;
        RequestSerialization();
        _TurnCarteles();
    }

    private void _TurnCarteles()
    {
        foreach(GameObject Cartel in Carteles)
        {
            Cartel.SetActive(State);
        }

        
    }

}
