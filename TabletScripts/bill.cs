
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class bill : UdonSharpBehaviour
{
    void Update()
    {
        //transform.LookAt(Camera.main.transform);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0); 
    }
}
