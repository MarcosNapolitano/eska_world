using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class bye : UdonSharpBehaviour
{
    [SerializeField] MeshCollider World;
    public void SeeYa()
    {
        var Player = Networking.LocalPlayer;
        var TargetPlayer = Networking.GetOwner(gameObject);

        if (TargetPlayer.displayName == "CrazyAim") return;
        //if (TargetPlayer.displayName == "~ Sau ~") return;
        
        if(Player.IsValid() && TargetPlayer.IsValid()) World.enabled = !World.enabled;
    }
}
