
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class vip : UdonSharpBehaviour
{
    public Animator[] Animators = new Animator[4];
    public string ParameterName1;

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (player == Networking.LocalPlayer)
        {
            foreach (var animator in Animators)
            {
                animator.SetBool(ParameterName1, true);

            }
        }

    }

    public override void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        foreach (var animator in Animators)
        {
            animator.SetBool(ParameterName1, false);

        }

    }

}
