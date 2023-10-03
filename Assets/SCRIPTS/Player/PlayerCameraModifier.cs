using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraModifier : MonoBehaviour {
    private PlayerManager _PlayerManager;
    public PlayerCamera _playerCamera;
    private int PriorityBoostAmount = 10;

    [Header("GameObject Camera Cinemachine")]
    public GameObject AIMCameraOption;
    public GameObject InventoryCameraOption;
    
    CinemachineVirtualCameraBase vcamAIM;
    CinemachineVirtualCameraBase vcamUI;
    CinemachineBrain cameraBrain;
    
    private void Awake() {
        _PlayerManager = GetComponentInParent<PlayerManager>();
        _playerCamera = GetComponent<PlayerCamera>();
        
    }

    void Start() {
        vcamAIM = AIMCameraOption.GetComponent<CinemachineVirtualCameraBase>();
        vcamUI = InventoryCameraOption.GetComponent<CinemachineVirtualCameraBase>();
        cameraBrain = gameObject.GetComponentInChildren<CinemachineBrain>();
        
        PlayerUsing.InventoryInput += SwitchToUI;
        PlayerUsing.ScopeInput += SwitchToAIM;
    }

    void SwitchToUI() {
        if (vcamUI != null) {
            if (_PlayerManager.boostedUI == false) {
                vcamUI.Priority += PriorityBoostAmount;
                cameraBrain.m_DefaultBlend.m_Time = 0.7f;
                _playerCamera.rotationSpeed = 0;
                
                _PlayerManager.boostedUI = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        PlayerUsing.InventoryInput -= SwitchToUI;
        PlayerUsing.InventoryInput += SwitchOutToUI;
    }
    void SwitchOutToUI() {
        if (vcamUI != null) {
            if (_PlayerManager.boostedUI) {
                vcamUI.Priority -= PriorityBoostAmount;
                _playerCamera.CameraSpeedValue();
                cameraBrain.m_DefaultBlend.m_Time = 0.2f;
                
                _PlayerManager.boostedUI = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        PlayerUsing.InventoryInput -= SwitchOutToUI;
        PlayerUsing.InventoryInput += SwitchToUI;
    }
    
    void SwitchToAIM() {
        if (vcamAIM != null) {
            if (_PlayerManager.boostedAIM == false) {
                    vcamAIM.Priority += PriorityBoostAmount;
                    _PlayerManager.boostedAIM = true;
            }
            else if (_PlayerManager.boostedAIM) {
                vcamAIM.Priority -= PriorityBoostAmount;
                _PlayerManager.boostedAIM = false;
            }
        }
    }
}
