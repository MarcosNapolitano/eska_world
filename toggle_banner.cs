
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class toggle_banner : UdonSharpBehaviour
{
    [UdonSynced] bool Creator = false;
    [UdonSynced] bool Owner = false;
    [UdonSynced] bool Art = false;
    [UdonSynced] bool Dj = false;
    [UdonSynced] bool Staff1 = false;
    [UdonSynced] bool Staff2 = false;
    [UdonSynced] bool Staff3 = false;
    [UdonSynced] bool Staff4 = false;
    [UdonSynced] bool Vip1 = false;
    [UdonSynced] bool Vip2 = false;
    [UdonSynced] bool Vip3 = false;
    [UdonSynced] bool Vip4 = false;
    [UdonSynced] bool Vip5 = false;
    [UdonSynced] bool Vip6 = false;


    public GameObject CreatorB;
    public GameObject OwnerB;
    public GameObject ArtB;
    public GameObject DjB;
    public GameObject Staff1B;
    public GameObject Staff2B;
    public GameObject Staff3B;
    public GameObject Staff4B;
    public GameObject Vip1B;
    public GameObject Vip2B;
    public GameObject Vip3B;
    public GameObject Vip4B;
    public GameObject Vip5B;
    public GameObject Vip6B;


    public override void OnDeserialization()
    {
        CreatorB.SetActive(Creator);
        OwnerB.SetActive(Owner);
        ArtB.SetActive(Art);
        DjB.SetActive(Dj);
        Staff1B.SetActive(Staff1);
        Staff2B.SetActive(Staff2);
        Staff3B.SetActive(Staff3);
        Staff4B.SetActive(Staff4);
        Vip1B.SetActive(Vip1);
        Vip2B.SetActive(Vip2);
        Vip3B.SetActive(Vip3);
        Vip4B.SetActive(Vip4);
        Vip5B.SetActive(Vip5);
        Vip6B.SetActive(Vip6);


    }

    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        switch (player.displayName)
        {

            case "CrazyAim":
                Networking.SetOwner(player, CreatorB);
                Networking.SetOwner(player, gameObject);
                Creator = true;
                CreatorB.SetActive(true);
                RequestSerialization();
                break;
            case "~ Sau ~":
                Networking.SetOwner(player, ArtB);
                Networking.SetOwner(player, gameObject);
                Art = true;
                ArtB.SetActive(true);
                RequestSerialization();
                break;
            case "Mustafaaǃ":
                Networking.SetOwner(player, DjB);
                Networking.SetOwner(player, gameObject);
                Dj = true;
                DjB.SetActive(true);
                RequestSerialization();
                break;
            case "LemisVT":
                Networking.SetOwner(player, OwnerB);
                Networking.SetOwner(player, gameObject);
                Owner = true;
                OwnerB.SetActive(true);
                RequestSerialization();
                break;
            case "bidondeaguaxl":
                Networking.SetOwner(player, Staff1B);
                Networking.SetOwner(player, gameObject);
                Staff1 = true;
                Staff1B.SetActive(true);
                RequestSerialization();
                break;
            case "Snowy_Y0z":
                Networking.SetOwner(player, Staff3B);
                Networking.SetOwner(player, gameObject);
                Staff3 = true;
                Staff3B.SetActive(true);
                RequestSerialization();
                break;
            case "bloodyghxsty":
                Networking.SetOwner(player, Staff4B);
                Networking.SetOwner(player, gameObject);
                Staff4 = true;
                Staff4B.SetActive(true);
                RequestSerialization();
                break;
            case "IAmNull":
                Networking.SetOwner(player, Staff2B);
                Networking.SetOwner(player, gameObject);
                Staff2 = true;
                Staff2B.SetActive(true);
                RequestSerialization();
                break;
            case "SoulTak":
                Networking.SetOwner(player, Vip1B);
                Networking.SetOwner(player, gameObject);
                Vip1 = true;
                Vip1B.SetActive(true);
                RequestSerialization();
                break;
            case "zaraexee":
                Networking.SetOwner(player, Vip2B);
                Networking.SetOwner(player, gameObject);
                Vip2 = true;
                Vip2B.SetActive(true);
                RequestSerialization();
                break;
            case "Olak1s0":
                Networking.SetOwner(player, Vip3B);
                Networking.SetOwner(player, gameObject);
                Vip3 = true;
                Vip3B.SetActive(true);
                RequestSerialization();
                break;
            case "bernasco111":
                Networking.SetOwner(player, Vip4B);
                Networking.SetOwner(player, gameObject);
                Vip4 = true;
                Vip4B.SetActive(true);
                RequestSerialization();
                break;
            case "Pollitoღ":
                Networking.SetOwner(player, Vip5B);
                Networking.SetOwner(player, gameObject);
                Vip5 = true;
                Vip5B.SetActive(true);
                RequestSerialization();
                break;
            case "koneh":
                Networking.SetOwner(player, Vip6B);
                Networking.SetOwner(player, gameObject);
                Vip6 = true;
                Vip6B.SetActive(true);
                RequestSerialization();
                break;
            default:
                break;
        }
    }

    public override void OnPlayerLeft(VRCPlayerApi player)
    {
        switch (player.displayName)
        {

            case "CrazyAim":
                Networking.SetOwner(Networking.InstanceOwner, gameObject);
                Creator = false;
                CreatorB.SetActive(false);
                RequestSerialization();
                break;
            case "~ Sau ~":
                Networking.SetOwner(Networking.InstanceOwner, gameObject);
                Art = false;
                ArtB.SetActive(false);
                RequestSerialization();
                break;
            case "Mustafaaǃ":
                Networking.SetOwner(Networking.InstanceOwner, gameObject);
                Dj = false;
                DjB.SetActive(false);
                RequestSerialization();
                break;
            case "LemisVT":
                Networking.SetOwner(Networking.InstanceOwner, gameObject);
                Owner = false;
                OwnerB.SetActive(false);
                RequestSerialization();
                break;
            case "bidondeaguaxl":
                Networking.SetOwner(Networking.InstanceOwner, gameObject);
                Staff1 = false;
                Staff1B.SetActive(false);
                RequestSerialization();
                break;
            case "Snowy_Y0z":
                Networking.SetOwner(Networking.InstanceOwner, gameObject);
                Staff3 = false;
                Staff3B.SetActive(false);
                RequestSerialization();
                break;
            case "bloodyghxsty":
                Networking.SetOwner(Networking.InstanceOwner, gameObject);
                Staff4 = false;
                Staff4B.SetActive(false);
                RequestSerialization();
                break;
            case "SoulTak":
                Networking.SetOwner(Networking.InstanceOwner, gameObject);
                Vip1 = false;
                Vip1B.SetActive(false);
                RequestSerialization();
                break;
            case "IAmNull":
                Networking.SetOwner(Networking.InstanceOwner, gameObject);
                Staff2 = false;
                Staff2B.SetActive(false);
                RequestSerialization();
                break;
            case "zaraexee":
                Networking.SetOwner(Networking.InstanceOwner, gameObject);
                Vip2 = false;
                Vip2B.SetActive(false);
                RequestSerialization();
                break;
            case "Olak1s0":
                Networking.SetOwner(Networking.InstanceOwner, gameObject);
                Vip3 = false;
                Vip3B.SetActive(false);
                RequestSerialization();
                break;
            case "bernasco111":
                Networking.SetOwner(Networking.InstanceOwner, gameObject);
                Vip4 = false;
                Vip4B.SetActive(false);
                RequestSerialization();
                break;
            case "Pollitoღ":
                Networking.SetOwner(Networking.InstanceOwner, gameObject);
                Vip5 = false;
                Vip5B.SetActive(false);
                RequestSerialization();
                break;
            case "koneh":
                Networking.SetOwner(Networking.InstanceOwner, gameObject);
                Vip6 = false;
                Vip6B.SetActive(false);
                RequestSerialization();
                break;
            default:
                break;
        }
    }

}
