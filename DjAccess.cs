
using System.Collections.Generic;
using System.Linq;
using UdonSharp;
using UnityEngine.UI;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRSL;
using VRC.SDKBase.Platform;
using TMPro;

public class DjAccess : UdonSharpBehaviour
{

    [SerializeField] GameObject[] CabinaDj = new GameObject[4];
    [SerializeField] GameObject Voice;
    [SerializeField] Renderer World;
    [SerializeField] Material RaveFloor;
    [SerializeField] Material RaveLight;
    [SerializeField] Material NormalLight;
    [SerializeField] Material Floor;
    [SerializeField] Material Walls;
    [SerializeField] Animator Pilar;
    [SerializeField] Slider _PilarSlider;
    [SerializeField] TextMeshProUGUI Cabina;


    //[SerializeField] GameObject Stage;
    //[SerializeField] GameObject Cilindro;
    //[SerializeField] GameObject Switch_Stage;
    //[SerializeField] GameObject Controls1;
    //[SerializeField] GameObject Controls2;
    //[SerializeField] GameObject Controls3;
    //[SerializeField] GameObject StageMirror;
    [SerializeField] GameObject[] Video = new GameObject[2];
    [SerializeField] GameObject[] Tablet = new GameObject[2];

    [UdonSynced] private bool EstadoCam = false;
    [UdonSynced] private bool EstadoStage = false;
    [UdonSynced] private bool EstadoMode = false;
    //[UdonSynced] private float PilarFloat = 0f;

    private float lastTime = 0f;
    private float threshold = 2f;

    public override void OnDeserialization()
    {
        _ChangeVideo();
        _ChangeStage();
        _ChangeMode();
        //_ChangePilar();
    }
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

    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        if (player == Networking.LocalPlayer & player == Networking.InstanceOwner)
        {
            _GrantAccess();
        }
    }
    //public override void OnOwnershipTransferred(VRCPlayerApi player)
    //{
    //    if (player == Networking.LocalPlayer)
    //    {
    //        _GrantAccess();
    //    }
    //}

    public void _GrantAccess() {

        foreach (GameObject i in CabinaDj)
        {
            i.SetActive(true);
        }

        foreach (GameObject i in Tablet)
        {
            i.SetActive(true);
        }

        Tablet[3].SetActive(false);
        Tablet[5].SetActive(false);


        //Collider.SetActive(false);
        //StageMirror.SetActive(true);

        //switch (Networking.LocalPlayer.displayName){
        //    case "CrazyAim":
        //        Switch_Stage.SetActive(true);
        //        break;
        //    case "~ Sau ~":
        //        Switch_Stage.SetActive(true);
        //        break;
        //    case "Mustafaaǃ":
        //        Switch_Stage.SetActive(true);
        //        break;
        //    case "LemisVT":
        //        Switch_Stage.SetActive(true);
        //        break;
        //}

    }
    public void _DenyAccess()
    {
        foreach(GameObject i in CabinaDj)
        {
            i.SetActive(false);
        }

        foreach (GameObject i in Tablet)
        {
            i.SetActive(false);
        }

        Tablet[3].SetActive(true);
        Tablet[5].SetActive(true);



        //Collider.SetActive(true);
        //StageMirror.SetActive(false);

        Tablet[0].transform.parent.parent.GetComponent<UdonBehaviour>().SendCustomEvent("_SelectPanel0");
    }
    public void _ToggleMode()
    {
        if (!_Cooldown()) return;

        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        EstadoMode = !EstadoMode;
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "EsferaIn");
        RequestSerialization();
        _ChangeMode();
    }
    public void _EnterSphere()
    {

        if (EstadoMode)
        {

            Material[] Materiales;
            Materiales = World.materials;

            Materiales[3] = RaveFloor;
            Materiales[11] = RaveFloor;
            Materiales[4] = RaveLight;

            World.materials = Materiales;

        }
        else
        {

            Material[] Materiales;
            Materiales = World.materials;

            Materiales[3] = Floor;
            Materiales[11] = Walls;
            Materiales[4] = NormalLight;

            World.materials = Materiales;

        }
    }

    private void _ChangeMode()
    {
        SendCustomEventDelayedSeconds("_EnterSphere", 1.2f);  

    }

    public void EsferaIn()
    {
        Pilar.SetBool("Rave", true);
        SendCustomEventDelayedSeconds("_EsferaOut", 1f);

    }

    public void _EsferaOut()
    {
        Pilar.SetBool("Rave", false);

    }

    public void _ToggleStage()
    {
        if (!_Cooldown()) return;

        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        EstadoStage = !EstadoStage;
        RequestSerialization();
        _ChangeStage();
    }

    private void _ChangeStage()
    {
        Pilar.SetBool("Cilindro", EstadoStage);
        if (EstadoStage) Cabina.text = "Subir Cabina";
        else Cabina.text = "Bajar Cabina";

    }
    public void _ToggleVideo()
    {
        if (!_Cooldown()) return;

        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        EstadoCam = !EstadoCam;
        RequestSerialization();
        _ChangeVideo();

    }
    private void _ChangeVideo()
    {
        foreach(GameObject Asset in Video)
        {
            Asset.SetActive(EstadoCam);
        }

        if (EstadoCam) Video[1].transform.SetPositionAndRotation(new Vector3(37.588f, -7.623f, -5.037f), Quaternion.Euler(-90, 0, 0));
    }

    //public void _GetPilar()
    //{
    //    if (!_Cooldown()) return;

    //    Networking.SetOwner(Networking.LocalPlayer, gameObject);
    //    PilarFloat = _PilarSlider.value;
    //    RequestSerialization();
    //    _ChangePilar();

    //}

    //private void _ChangePilar()
    //{
    //    Pilar.SetFloat("Pilar", PilarFloat);
    //}

}
