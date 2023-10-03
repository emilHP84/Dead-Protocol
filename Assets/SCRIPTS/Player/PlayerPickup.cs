using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class PlayerPickup : MonoBehaviour {
    [SerializeField] private PlayerInventory _playerInventory;

    public void DoPickUp(Item item) {
        if (_playerInventory.Isfull()) return;
        _playerInventory.AddItem(item.item);
        Destroy(item.gameObject);
    }
}
