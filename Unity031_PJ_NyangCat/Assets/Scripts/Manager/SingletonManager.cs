using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManager : MonoBehaviour
{
    public static SingletonManager instance;

    [SerializeField] MasterManager masterManager = null;
    [SerializeField] CameraManager cameraManager = null;

    private void Awake()
    {
        instance = this;


    }

}
