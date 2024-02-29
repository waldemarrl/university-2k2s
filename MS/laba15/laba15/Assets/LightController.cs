using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightController : MonoBehaviour
{
    public Light light;
    private void OnTriggerEnter(Collider other)
    {
        light.intensity = 100;
    }

    private void OnTriggerExit(Collider other)
    {
        light.intensity = 0;
    }
}
