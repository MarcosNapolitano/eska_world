
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class wellcome : UdonSharpBehaviour
{
    public Animator anim1, anim2;
    public GameObject Wellcome;
    public string ParameterName1, ParameterName2;
    public bool Param;

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (player == Networking.LocalPlayer)
        {
            anim1.SetBool(ParameterName1, Param);
            anim2.SetBool(ParameterName2, Param);
        }

        if (!Param)
        {
            SendCustomEventDelayedSeconds("_toggleOff", 15f);
        }
    }
    
    public void _toggleOff()
    {
        Wellcome.SetActive(false);
    }

}
