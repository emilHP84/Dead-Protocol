using System;
using UnityEngine;

public class PlayerUsing : MonoBehaviour {
    private PlayerManager _PlayerManager;

    [SerializeField] private KeyCode keyCodeReload;
    [SerializeField] private KeyCode keyCodeInteract;
    
    public static Action ShootInput;
    public static Action ReloadInput;
    public static Action InteractInput;
    
    private void Awake() {
        _PlayerManager = GetComponent<PlayerManager>();
    }
    
    private void Update() {
        if (Input.GetMouseButtonDown(0)) ShootInput?.Invoke();
        if (Input.GetKeyDown(keyCodeInteract)) InteractInput?.Invoke();
        if (Input.GetKeyDown(keyCodeReload)) ReloadInput?.Invoke();
    }
}
