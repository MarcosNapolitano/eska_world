
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;

public class ResetBrisca : UdonSharpBehaviour
{
    [SerializeField] VRCObjectPool Deck;
    [SerializeField] GameObject Mazo;
    [SerializeField] UdonBehaviour Deal;

    //private void OnEnable()
    //{
    //    Reset();

    //}

    public override void Interact()
    {
        var LocalPlayer = Networking.LocalPlayer;
        var MazoOwner = Networking.GetOwner(Mazo);

        if (LocalPlayer == MazoOwner)
        {
            if (LocalPlayer == Networking.GetOwner(gameObject)) Reset();
            return;

        }
        //SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, "Reset");
    }


    public void Reset()
    {
        for (int i = 0; i < Deck.Pool.Length; i++)
        {
            Deck.Return(Deck.Pool[i]);
        }

        Deal.SetProgramVariable("partidaActiva", false);

    }
}
