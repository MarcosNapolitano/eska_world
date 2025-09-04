
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class send_stage : UdonSharpBehaviour
{
    [SerializeField] UdonBehaviour DJ;

    public override void Interact()
    {
        DJ.SendCustomEvent("_ToggleStage");
    }

}
