
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Enums;

public class CartelNuestro : UdonSharpBehaviour
{
    [SerializeField] GameObject[] Carteles = new GameObject[2];
    private int index = 0;
    public int limit = 0;


    void Start()
    {
        _SwitchOn();
    }

    public void _SwitchOn()
    {

        Carteles[index].SetActive(true);


        SendCustomEventDelayedSeconds("_AnimateOut", 10, EventTiming.Update);

    }

    public void _AnimateOut()
    {

        Carteles[index].GetComponent<Animator>().SetBool("Exit", true);
        index++;
        if (index == limit) index = 0;
        SendCustomEventDelayedSeconds("_SwitchOff", 1.4f, EventTiming.Update);
        _SwitchOn();

    }

    public void _SwitchOff()
    {

        if (index == 0)
        {
            Carteles[limit - 1].SetActive(false);
            return;
        }

        Carteles[index - 1].SetActive(false);



    }
}
