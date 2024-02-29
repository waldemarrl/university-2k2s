using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_GetAxis : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float LookSensitivity = 3f;

    private float _xRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");

        var moveDirection = new Vector3(horizontal, 0, vertical);
        transform.Translate(moveDirection.normalized * MoveSpeed * Time.deltaTime);

        transform.Rotate(0, mouseX * LookSensitivity, 0);

        _xRotation -= mouseY * LookSensitivity;
        _xRotation = Mathf.Clamp(_xRotation, 0, 90);
        transform.localRotation = Quaternion.Euler(_xRotation, transform.localRotation.eulerAngles.y, 0);
    }
}

