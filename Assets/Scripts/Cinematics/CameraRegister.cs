using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class CameraRegister : MonoBehaviour
{
    public void OnEnable()
    {
        CamaraManager.Register(GetComponent<CinemachineCamera>());
    }

    public void OnDisable()
    {
        CamaraManager.Unregister(GetComponent<CinemachineCamera>());
    }
}
