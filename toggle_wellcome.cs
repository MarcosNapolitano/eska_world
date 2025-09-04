
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class toggle_wellcome : UdonSharpBehaviour
{
    [SerializeField] GameObject wellcome;

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if(player == Networking.LocalPlayer) {
            wellcome.SetActive(false);

        }
    }
}
