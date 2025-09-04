
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class dj_toggles : UdonSharpBehaviour
{
    [SerializeField] Animator anim1;
    [SerializeField] string ParameterName1;
    [UdonSynced] private bool estado = false;
    [SerializeField] GameObject asset;

    public override void OnDeserialization()
    {
        toggle();
    }

    public override void Interact()
    {
        
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        estado = !estado;
        RequestSerialization();
        anim1.SetBool(ParameterName1, estado);
        toggle();


    }

    private void toggle()
    {
        asset.SetActive(estado);
    }
}
