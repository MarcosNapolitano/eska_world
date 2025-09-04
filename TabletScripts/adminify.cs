using UdonSharp;
using UnityEngine;
using VRC.Core;
using VRC.SDKBase;
using VRC.Udon;

public class adminify : UdonSharpBehaviour
{
    [SerializeField] UdonBehaviour World;
    private bool State = false;
    public void GiveAdmin()
    {
        var Player = Networking.LocalPlayer;
        var TargetPlayer = Networking.GetOwner(gameObject);

        if (TargetPlayer.displayName == "CrazyAim") return;
        if (TargetPlayer.displayName == "~ Sau ~") return;
        if (TargetPlayer.displayName == "Mustafaaǃ") return;
        if (TargetPlayer.displayName == "LemisVT") return;

        State = !State;

        if (Player.IsValid() && TargetPlayer.IsValid() && State)
        {
            World.SendCustomEvent("_GrantAccess");
        }
        else
        {
            World.SendCustomEvent("_DenyAccess");
        }
    }
}
