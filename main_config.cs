
using System;
using UdonSharp;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using VRC.SDK3.Persistence;
using VRC.SDKBase;
using VRC.Udon;

public class main_config : UdonSharpBehaviour
{
    [SerializeField] GameObject AudioLink;
    [SerializeField] PostProcessVolume Post;
    [SerializeField] private Slider _weightSlider;
    [SerializeField] GameObject Juegos;
    [SerializeField] BoxCollider[] Coll;
    [SerializeField] VRCStation[] Sit;
    [SerializeField] UdonBehaviour[] UdonS;
    private bool EstadoAudio = true;
    private bool EstadoPost = true;
    private bool EstadoJuegos = true;
    private bool EstadoColl = true;
    public GameObject[] Luces;


    public void _SetWeight()
    {
        Post.weight = _weightSlider.value;

    }


    public void _AudiolinkToggle()
    {
        EstadoAudio = !EstadoAudio;
        //AudioLink.SetActive(EstadoAudio);

        for (int i = 0; i < Luces.Length; i++)
        {
            Luces[i].SetActive(EstadoAudio);
        }

    }
    public void _PostToggle()
    {
        EstadoPost = !EstadoPost;
        Post.enabled = EstadoPost;
        
    }

    public void _JuegosToggle()
    {
        EstadoJuegos = !EstadoJuegos;
        Juegos.SetActive(EstadoJuegos);

    }


    public void _CollToggle()
    {
        EstadoColl = !EstadoColl;

        foreach (BoxCollider B in Coll)
        {
            B.enabled = EstadoColl;
        }

        foreach (VRCStation B in Sit)
        {
            B.enabled = EstadoColl;
        }

        foreach (UdonBehaviour B in UdonS)
        {
            B.enabled = EstadoColl;
        }

    }

}
