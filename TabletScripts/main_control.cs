
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class main_control : UdonSharpBehaviour
{

    [SerializeField] GameObject AdminFunc;
    [SerializeField] GameObject Panel0;
    [SerializeField] GameObject Panel1;
    [SerializeField] GameObject Panel2;
    [SerializeField] GameObject Panel3;
    

    private char PanelNumber = '0';

    public void _SelectPanel1()
    {
        PanelNumber = '1';
        _ChangePanel();

    }

    public void _SelectPanel2()
    {
        PanelNumber = '2';
        _ChangePanel();
    }

    public void _SelectPanel3()
    {
        PanelNumber = '3';
        _ChangePanel();
    }

    public void _SelectPanel0()
    {
        PanelNumber = '0';
        _ChangePanel();
    }

    private void _ChangePanel()
    {

        switch (PanelNumber)
        {
            case '1':
                Panel1.SetActive(true);
                Panel2.SetActive(false);
                Panel3.SetActive(false);
                Panel0.SetActive(false);
                break;
            case '2':
                Panel2.SetActive(true);
                Panel1.SetActive(false);
                Panel3.SetActive(false);
                Panel0.SetActive(false);
                break;
            case '3':
                Panel3.SetActive(true);
                Panel1.SetActive(false);
                Panel2.SetActive(false);
                Panel0.SetActive(false);
                break;
            case '0':
                Panel0.SetActive(true);
                Panel1.SetActive(false);
                Panel2.SetActive(false);
                Panel3.SetActive(false);
                break;


        }

    }


}
