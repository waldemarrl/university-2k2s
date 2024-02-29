using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Quantum : MonoBehaviour
{
    // Start is called before the first frame update
    Quaternion orig;
    float angl;
    void Start()
    {  
        orig = transform.rotation;  
    }
    void Update()
    {  
        angl += 3.0f;
        Quaternion rotY = Quaternion.AngleAxis(angl, Vector3.up);
        transform.rotation = orig * rotY;    
	}

}
