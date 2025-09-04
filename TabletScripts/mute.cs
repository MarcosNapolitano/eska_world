
using System.Security.Policy;
using TMPro;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class mute : UdonSharpBehaviour
{
    [UdonSynced] bool muted = false;

    public override void OnDeserialization()
    {
        MutePlayer();
    }

    public void ToggleMute()
    {
        muted = !muted;
        RequestSerialization();
        MutePlayer();
    }

    public void MutePlayer()
    {
        var Player = Networking.LocalPlayer;
        var TargetPlayer = Networking.GetOwner(gameObject);

        if (Player.IsValid() && TargetPlayer.IsValid())
        {
            if (muted)
            {
                if(Player == TargetPlayer)
                {
                    //Player.SetVoiceDistanceFar(0);
                    //Player.SetAvatarAudioFarRadius(0);
                    Player.SetVoiceGain(18);
                    Player.SetVoiceDistanceNear(999999);
                    Player.SetVoiceDistanceFar(1000000);
                    Player.SetVoiceVolumetricRadius(1000);
                    return;
                }

                //TargetPlayer.SetVoiceDistanceFar(0);
                //TargetPlayer.SetAvatarAudioFarRadius(0);
                TargetPlayer.SetVoiceGain(18);
                TargetPlayer.SetVoiceDistanceNear(999999);
                TargetPlayer.SetVoiceDistanceFar(1000000);
                TargetPlayer.SetVoiceVolumetricRadius(1000);
            }
            else
            {
                if(Player == TargetPlayer)
                {
                    //Player.SetVoiceDistanceFar(25);
                    //Player.SetAvatarAudioFarRadius(40);
                    Player.SetVoiceGain(15);
                    Player.SetVoiceDistanceNear(0);
                    Player.SetVoiceDistanceFar(25);
                    Player.SetVoiceVolumetricRadius(0.05f);
                    Player.SetVoiceLowpass(true);
                    return;
                }

                //TargetPlayer.SetVoiceDistanceFar(25);
                //TargetPlayer.SetAvatarAudioFarRadius(40);
                TargetPlayer.SetVoiceGain(15);
                TargetPlayer.SetVoiceDistanceNear(0);
                TargetPlayer.SetVoiceDistanceFar(25);
                TargetPlayer.SetVoiceVolumetricRadius(0.05f);
                TargetPlayer.SetVoiceLowpass(true);
            }
            
        }
    }
}
