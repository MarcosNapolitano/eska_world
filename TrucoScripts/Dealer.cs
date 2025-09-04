
using System;
using System.Collections;
using TMPro;
using UdonSharp;
using Unity.Mathematics;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;

public class Dealer : UdonSharpBehaviour
{
    [SerializeField] VRCObjectPool Deck;
    [SerializeField] UdonBehaviour Menu;
    [SerializeField] GameObject Reset;

    [SerializeField] TextMeshProUGUI jugadorActivo;
    [SerializeField] Transform[] player2 = new Transform[2];
    [SerializeField] Transform[] player4 = new Transform[4];
    [SerializeField] Transform[] player6 = new Transform[6];

    [SerializeField] Transform[] play2 = new Transform[2];
    [SerializeField] Transform[] play4 = new Transform[4];
    [SerializeField] Transform[] play6 = new Transform[6];

    [UdonSynced] int players;
    [UdonSynced] float playCount = 0.0f;
    [UdonSynced] bool partidaActiva = false;
    [UdonSynced] string jugador;


    public override void Interact()
    {
        if (partidaActiva) return;

        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        Networking.SetOwner(Networking.LocalPlayer, Deck.gameObject);
        Networking.SetOwner(Networking.LocalPlayer, Reset);
        jugador = Networking.LocalPlayer.displayName;
        partidaActiva = true;
        _SetPlayer();
        RequestSerialization();

        _Deal();

      
    }

    public override void OnDeserialization()
    {
        _SetPlayer();
    }

    private void _setCardPlacement(Transform[] playerPos, Transform[] cardPos, int index, GameObject card)
    {
        Networking.SetOwner(Networking.LocalPlayer, card);
        Networking.SetOwner(Networking.LocalPlayer, card.transform.GetChild(2).gameObject);

        card.transform.SetPositionAndRotation(playerPos[index].transform.position, playerPos[index].transform.rotation);
        card.transform.GetChild(2).GetComponent<UdonBehaviour>().SetProgramVariable("Pos", cardPos[index].transform.position);
        card.transform.GetChild(2).GetComponent<UdonBehaviour>().SetProgramVariable("Rot", cardPos[index].transform.rotation);
    }


    public void _Deal()
    {

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

                    case 6:

                        _setCardPlacement(player6, play6, counter, card);

                        if (counter == 5)
                        {
                            counter = 0;
                            continue;
                        }
                        break;
                }

            }
            counter++;
        }
    }

    public void _SetPlayer() {
        
        jugadorActivo.text = jugador;

    }

}
