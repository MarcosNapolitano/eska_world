
using UdonSharp;
using UnityEngine;
using UnityEngine.UIElements;
using VRC.SDKBase;
using VRC.Udon;

public class look : UdonSharpBehaviour
{
    [SerializeField] Camera Player;

    void Update()
    {
        transform.forward = Player.transform.forward;
    }
}
