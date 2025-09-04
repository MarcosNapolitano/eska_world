
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class follow : UdonSharpBehaviour
{

    [SerializeField] GameObject AdminCartel;
    [UdonSynced] bool estado = false;


    public override void OnDeserialization()
    {
        GrantAccess();
    }

    public void CartelToggle()
    {
        estado = !estado;
        RequestSerialization();
        GrantAccess();
    }

    private void GrantAccess()
    {
        AdminCartel.SetActive(estado);
    }
}
