
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class select_player : UdonSharpBehaviour
{
    [SerializeField] fill_players Contenedor1;
    [SerializeField] AdminFunc Contenedor2;
    public int ID;

    public void _SetPlayer()
    {
        Contenedor1._SetPlayerName(ID);
        Contenedor2._SetPlayer(ID);
    }

}
