using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public Light Spot1;
    public Light Spot2;

    void OnTriggerStay(Collider col)
    {
        if (col.name == "player" || col.name == "robot")
        {
            Spot1.transform.Rotate(0f, Time.deltaTime * 500f, 0f);
            Spot2.transform.Rotate(0f, Time.deltaTime * 500f, 0f);
        }
    }
}
