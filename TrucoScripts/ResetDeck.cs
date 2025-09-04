
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;

public class ResetDeck : UdonSharpBehaviour
{
    [SerializeField] VRCObjectPool Deck;
    [SerializeField] GameObject Mazo;
    [SerializeField] UdonBehaviour Deal;
    [SerializeField] UdonBehaviour PlayerMenu;

    [SerializeField] GameObject Cartel;



    private void OnEnable()
    {
        Reset();

    }

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
        Deal.SetProgramVariable("playCount", 0.0f);
        Cartel.SetActive(false);

        PlayerMenu.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "resetButtons");
        PlayerMenu.SetProgramVariable("canto", "");
    }
}
