
using UdonSharp;
using UnityEngine;
using VRC.Core;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;

public class GetHere : UdonSharpBehaviour
{
    private float lastLeftTriggerTime = 0f;
    private float doublePressThreshold = .5f;

    public override void InputUse(bool value, UdonInputEventArgs args)
    {
        if (!value || !Networking.LocalPlayer.IsUserInVR()) return;

        if (args.handType != HandType.LEFT) return;

        if (Time.time - lastLeftTriggerTime < doublePressThreshold)
        {
            _GetHereNow();
            lastLeftTriggerTime = 0f;
        }
        else
        {
            lastLeftTriggerTime = Time.time;
        }
    }

    public override void InputDrop(bool value, UdonInputEventArgs args)
    {
        if (!value || Networking.LocalPlayer.IsUserInVR()) return;

        if (args.handType != HandType.RIGHT) return;

        if (Time.time - lastLeftTriggerTime < doublePressThreshold)
        {
            _GetHereNow();
            lastLeftTriggerTime = 0f;
        }
        else
        {
            lastLeftTriggerTime = Time.time;
        }
    }

    private void _GetHereNow()
    {
        var rotation = Quaternion.Euler(14, Networking.LocalPlayer.GetRotation().eulerAngles.y, 0);
        gameObject.transform.SetPositionAndRotation(Networking.LocalPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.LeftHand).position, rotation);

    }
}
