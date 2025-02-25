﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookScript : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up, mouseX);
    }
}
