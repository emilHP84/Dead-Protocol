using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    private float RotationSpeedValue = 2.0f;
    public float rotationSpeed;

    private float mouseX;
    private float mouseY;

    public void CameraSpeedValue() {
        rotationSpeed = RotationSpeedValue;
    }

    void LateUpdate() {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -80f, 80f);

        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
        transform.rotation = rotation;
    }
}

