
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class freeze : UdonSharpBehaviour
{
    [UdonSynced] bool freezed = false;


    public override void OnDeserialization()
    {
        FreezePlayer();
    }

    public void ToggleFreeze()
    {
        freezed = !freezed;
        RequestSerialization();
        FreezePlayer();
    }

    public void FreezePlayer()
    {
        var Player = Networking.LocalPlayer;

        if (Player.IsValid() && Networking.IsOwner(Player, gameObject))
        {
            Player.Immobilize(freezed);
            
        }
    }
}