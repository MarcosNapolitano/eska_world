
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class dj_toggles2 : UdonSharpBehaviour
{
    [SerializeField] Animator anim1;
    [SerializeField] string ParameterName1;
    [UdonSynced] private bool estado = false;

    public override void OnDeserialization()
    {
        _Toggle();
    }

    public void _ToggleTest()
    {
        
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        estado = !estado;
        RequestSerialization();
        _Toggle();


    }

    private void _Toggle()
    {
        anim1.SetBool(ParameterName1, estado);
    }

}
