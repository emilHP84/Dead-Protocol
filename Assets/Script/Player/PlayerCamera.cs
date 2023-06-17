using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    public PlayerManager _PlayerManager;

    public float rotationSpeed = 2.0f;

    private float mouseX;
    private float mouseY;


    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -80f, 80f);

        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
        transform.rotation = rotation;
    }
}

