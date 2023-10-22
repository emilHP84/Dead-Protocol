using System;
using UnityEngine;

public class EventManager : MonoBehaviour {
    
    [Header("weapon setting")]
    [SerializeField]private KeyCode keyCodeReload;
    [SerializeField] private KeyCode keyCodeScope;
    [SerializeField] private KeyCode keyCodeShoot;

    [Header("interact setting")]
    [SerializeField] private KeyCode keyCodeInteract;

    [Header("inventory setting")] 
    [SerializeField] private KeyCode keyCodeInventory;

    public static Action ShootInput;
    public static Action ReloadInput;
    public static Action ScopeInput;
    public static Action InteractInput;
    public static Action InventoryInput;
    
    private void Update() {
        if (Input.GetMouseButtonDown(1)) Inventory.instance.CloseActionPanel();
        if (Input.GetKeyDown(keyCodeScope)) ScopeInput?.Invoke();
        if (Input.GetKeyUp(keyCodeScope)) ScopeInput?.Invoke();
        if (Input.GetKeyDown(keyCodeShoot)) ShootInput?.Invoke();
        if (Input.GetKeyDown(keyCodeReload)) ReloadInput?.Invoke();
        if (Input.GetKeyDown(keyCodeInteract)) InteractInput?.Invoke();
        if (Input.GetKeyDown(keyCodeInventory)) InventoryInput?.Invoke();
    }

}
