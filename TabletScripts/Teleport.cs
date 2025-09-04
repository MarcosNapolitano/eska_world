
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Teleport : UdonSharpBehaviour
{

    [SerializeField] Transform Destination;
    [SerializeField] Transform RespawnPoint;

    public void TeleportPlayer()
    {
        var Player = Networking.LocalPlayer;

        if (Player.IsValid() && Networking.IsOwner(Player, gameObject))
        {
            Player.TeleportTo(Destination.position, Destination.rotation);
            RespawnPoint.position = Destination.position;
            RespawnPoint.rotation = Destination.rotation;
        
        }
        
    }
}
