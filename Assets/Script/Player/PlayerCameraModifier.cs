using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraModifier : MonoBehaviour {
    private PlayerManager _PlayerManager;
    public PlayerCamera _playerCamera;
    
    [Header("KeyCode Parameter")]
    public KeyCode AIMKey = KeyCode.E;
    public KeyCode UIKey = KeyCode.I;
    
    [Header("Optional Parameter")]
    public int PriorityBoostAmount = 10;

    [Header("GameObject Camera Cinemachine")]
    public GameObject AIMCameraOption;
    public GameObject InventoryCameraOption;
    
    Cinemachine.CinemachineVirtualCameraBase vcamAIM;
    Cinemachine.CinemachineVirtualCameraBase vcamUI;
    
    private void Awake() {
        _PlayerManager = GetComponentInParent<PlayerManager>();
        _playerCamera = GetComponent<PlayerCamera>();
    }

    void Start() {
        vcamAIM = AIMCameraOption.GetComponent<Cinemachine.CinemachineVirtualCameraBase>();
        vcamUI = InventoryCameraOption.GetComponent<Cinemachine.CinemachineVirtualCameraBase>();
        _playerCamera = gameObject.GetComponent<PlayerCamera>();
    }

    void Update() {
        if (vcamAIM != null) {
            if (Input.GetKey(AIMKey)) {
                if (_PlayerManager.boostedAIM == false) {
                    vcamAIM.Priority += PriorityBoostAmount;
                   _PlayerManager.boostedAIM = true;
                }
            }
            else if (_PlayerManager.boostedAIM) {
                vcamAIM.Priority -= PriorityBoostAmount;
                _PlayerManager.boostedAIM = false;
            }
        }
        
        if (vcamUI != null) {
            if (Input.GetKeyDown(UIKey) && _PlayerManager.boostedUI == false) {
                vcamUI.Priority += PriorityBoostAmount;
                _playerCamera.rotationSpeed = 0;
                
                _PlayerManager.boostedUI = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            if (Input.GetKeyDown(KeyCode.Escape)) {
                vcamUI.Priority -= PriorityBoostAmount;
                _playerCamera.CameraSpeedValue();
                
                _PlayerManager.boostedUI = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
