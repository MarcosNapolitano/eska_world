
using TMPro;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;

public class fill_players : UdonSharpBehaviour
{
    [SerializeField] GameObject boton;
    [SerializeField] Button B1, B2, B3, B4;
    [SerializeField] TextMeshProUGUI SelectedPlayerText;
    private VRCPlayerApi[] Players;

    private float lastTime = 0f;
    private float threshold = 2f;
    private bool _Cooldown()
    {
        if (lastTime - Time.time <= threshold)
        {
            lastTime = Time.time;
            return true;
        }
        else
        {
            lastTime = Time.time;
            return false;
        }

    }

    void Start()
    {

        _FillPlayers();

    }

    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        _FillPlayers();
    }

    public override void OnPlayerLeft(VRCPlayerApi player)
    {
        _FillPlayers();
    }

    public void _FillPlayers()
    {
        if (!_Cooldown()) return;

        _DequeuePlayers();

        Players = VRCPlayerApi.GetPlayers(new VRCPlayerApi[VRCPlayerApi.GetPlayerCount()]);
        _FillButton(boton, Players[0]);

        for (int i = 1; i < Players.Length; i++)
        {
            var nuevoBoton = Object.Instantiate(boton, gameObject.transform, false);
            _FillButton(nuevoBoton, Players[i]);

        }
    }

    public void _FillButton(GameObject Button, VRCPlayerApi Player)
    {
        Button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Player.displayName;
        Button.GetComponent<UdonBehaviour>().SetProgramVariable("ID", Player.playerId);
    }

    private void _DequeuePlayers()
    {
        if (gameObject.transform.childCount == 1) return;

        for (int i = 1; i < gameObject.transform.childCount; i++) Destroy(gameObject.transform.GetChild(i).gameObject);
        
    }

    public void _SetPlayerName(int ID)
    {
        var player = VRCPlayerApi.GetPlayerById(ID);
        SelectedPlayerText.text = player.displayName;
        B1.interactable = true;
        B2.interactable = true;
        B3.interactable = true;
        B4.interactable = true;

    }





}
