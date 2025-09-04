
using System;
using System.Reflection;
using TMPro;
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;

public class BriscaDealer : UdonSharpBehaviour
{
    [SerializeField] VRCObjectPool Deck;
    [SerializeField] UdonBehaviour Menu;
    [SerializeField] GameObject Reset;
    [SerializeField] Transform Palo;


    [SerializeField] Transform[] player2 = new Transform[2];
    [SerializeField] Transform[] player4 = new Transform[4];

    [SerializeField] Transform[] play2 = new Transform[2];
    [SerializeField] Transform[] play4 = new Transform[4];

    [UdonSynced] int players;
    [UdonSynced] bool partidaActiva = false;


    public override void Interact()
    {

        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        Networking.SetOwner(Networking.LocalPlayer, Reset);

        if(!partidaActiva) _Deal();

        else {

            var card = Deck.TryToSpawn();
            Networking.SetOwner(Networking.LocalPlayer, card);
            Networking.SetOwner(Networking.LocalPlayer, card.transform.GetChild(2).gameObject);
        };

    }

    private void _setCardPlacement(Transform[] playerPost, Transform[] cardPos, int index, GameObject card)
    {
        Networking.SetOwner(Networking.LocalPlayer, card);
        Networking.SetOwner(Networking.LocalPlayer, card.transform.GetChild(2).gameObject);

        card.transform.SetPositionAndRotation(playerPost[index].transform.position, playerPost[index].transform.rotation);
        card.transform.GetChild(2).GetComponent<UdonBehaviour>().SetProgramVariable("Pos", cardPos[index].transform.position);
        card.transform.GetChild(2).GetComponent<UdonBehaviour>().SetProgramVariable("Rot", cardPos[index].transform.rotation);
    }


    public void _Deal()
    {
        partidaActiva = true;

        players = Convert.ToInt32(Menu.GetProgramVariable("playerCount"));

        Deck.Shuffle();

        var counter = 0;

        for (int i = 0; i < players * 3; i++)
        {
            var card = Deck.TryToSpawn();

            if (Utilities.IsValid(card))
            {
                switch (players)
                {
                    case 2:

                        _setCardPlacement(player2, play2, counter, card);

                        if (counter == 1)
                        {
                            counter = 0;
                            continue;
                        }
                        break;

                    case 4:

                        _setCardPlacement(player4, play4, counter, card);

                        if (counter == 3)
                        {
                            counter = 0;
                            continue;
                        }
                        break;

                }

            }
            counter++;
        }

        var palo = Deck.TryToSpawn();
        Networking.SetOwner(Networking.LocalPlayer, palo);
        Networking.SetOwner(Networking.LocalPlayer, palo.transform.GetChild(2).gameObject);
        palo.transform.SetPositionAndRotation(Palo.position, Palo.rotation);

    }
}
