
using System.Drawing.Text;
using UdonSharp;
using UnityEngine;
using UnityEngine.Android;
using VRC.SDKBase;
using VRC.Udon;

public class follow_admin : UdonSharpBehaviour
{
    public VRCPlayerApi Player = Networking.LocalPlayer;
    private bool estado = false;

    void Start()
    {

        if (Player.GetPlayerTag("Admin") == "Admin")
        {
            estado = true;
        }

    }


    void Update()
    {
        if (estado) {

            gameObject.transform.SetPositionAndRotation(Player.GetPosition(), Player.GetRotation());
        }
    }

    public override void OnPlayerLeft(VRCPlayerApi player)
    {
        if (player == Player)
        {
            estado = !estado;
            gameObject.SetActive(estado);
        }
    }
}
