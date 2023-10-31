using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private PlayerManager _PlayerManager;
    private int PriorityBoostAmount = 10;

    [Header("GameObject Camera Cinemachine")]
    public GameObject AIMCameraOption;
    public GameObject InventoryCameraOption;

    CinemachineVirtualCameraBase vcamAIM;
    CinemachineVirtualCameraBase vcamUI;
    CinemachineBrain cameraBrain;

    private float RotationSpeedValue = 2.0f;
    public float rotationSpeed;

    private float mouseX;
    private float mouseY;

    private void Awake()
    {
        _PlayerManager = GetComponentInParent<PlayerManager>();
    }

    void Start()
    {
        vcamAIM = AIMCameraOption.GetComponent<CinemachineVirtualCameraBase>();
        vcamUI = InventoryCameraOption.GetComponent<CinemachineVirtualCameraBase>();
        cameraBrain = gameObject.GetComponentInChildren<CinemachineBrain>();

        EventManager.InventoryInput += SwitchToUI;
        EventManager.ScopeInput += SwitchToAIM;
    }

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


    void SwitchToUI()
    {
        if (vcamUI != null)
        {
            if (_PlayerManager.boostedUI == false)
            {
                vcamUI.Priority += PriorityBoostAmount;
                cameraBrain.m_DefaultBlend.m_Time = 0.7f;
                rotationSpeed = 0;

                _PlayerManager.boostedUI = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        EventManager.InventoryInput -= SwitchToUI;
        EventManager.InventoryInput += SwitchOutToUI;
    }
    void SwitchOutToUI()
    {
        if (vcamUI != null)
        {
            if (_PlayerManager.boostedUI)
            {
                vcamUI.Priority -= PriorityBoostAmount;
                CameraSpeedValue();
                cameraBrain.m_DefaultBlend.m_Time = 0.2f;

                _PlayerManager.boostedUI = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        EventManager.InventoryInput -= SwitchOutToUI;
        EventManager.InventoryInput += SwitchToUI;
    }

    void SwitchToAIM()
    {
        if (vcamAIM != null)
        {
            if (_PlayerManager.boostedAIM == false)
            {
                vcamAIM.Priority += PriorityBoostAmount;
                _PlayerManager.boostedAIM = true;
            }
            else if (_PlayerManager.boostedAIM)
            {
                vcamAIM.Priority -= PriorityBoostAmount;
                _PlayerManager.boostedAIM = false;
            }
        }
    }
}

