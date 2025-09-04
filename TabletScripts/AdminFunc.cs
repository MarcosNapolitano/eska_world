using System;
using TMPro;
using UdonSharp;
using UnityEngine;
using UnityEngine.Assertions.Must;
using VRC.SDKBase;
using VRC.Udon;

public class AdminFunc : UdonSharpBehaviour
{
    [UdonSynced] int SelectedId;

    [SerializeField] mute Mute;
    [SerializeField] freeze Freeze;
    [SerializeField] Teleport Teleport;
    [SerializeField] adminify Admin;
    [SerializeField] bye Bye;

    private float lastTime = 0f;
    private float threshold = 2f;
    private bool _Cooldown()
    {
        if (lastTime - Time.time <= threshold)
        {
            lastTime = Time.time;
            return true;
        }
        else
        {
            lastTime = Time.time;
            return false;
        }
    }

    public VRCPlayerApi _SelectPlayer()
    {
        return VRCPlayerApi.GetPlayerById(SelectedId);
    }

    public void _MutePlayer()
    {
        if (!_Cooldown()) return;

        Networking.SetOwner(_SelectPlayer(), Mute.gameObject);
        Mute.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, "ToggleMute");
    }

    public void _FreezePlayer()
    {
        if (!_Cooldown()) return;

        Networking.SetOwner(_SelectPlayer(), Freeze.gameObject);
        Freeze.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, "ToggleFreeze");
    }

    public void _TeleportPlayer()
    {
        _FreezePlayer();
        Networking.SetOwner(_SelectPlayer(), Teleport.gameObject);
        Teleport.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, "TeleportPlayer");

    }

    public void _NiNos()
    {
        if (!_Cooldown()) return;

        Networking.SetOwner(_SelectPlayer(), Bye.gameObject);
        Bye.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, "SeeYa");
    }

    public void _GiveAdmin()
    {
        if (!_Cooldown()) return;

        Networking.SetOwner(_SelectPlayer(), Admin.gameObject);
        Admin.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, "GiveAdmin");
    }

    public void _SetPlayer(int ID)
    {
        SelectedId = ID;
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        RequestSerialization();
    }

}
