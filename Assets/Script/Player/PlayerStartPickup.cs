using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PlayerStartPickup : MonoBehaviour {
    public PlayerPickup _PlayerPickup;
    
    [SerializeField]private float pickupRange;
    private RaycastHit hit;

    private void Start() {
        PlayerUsing.InteractInput += StartPick;
    }

    private bool IsPickable() => Physics.Raycast(transform.position, transform.forward, out hit, pickupRange) &&
                                 hit.transform.GetComponent<Item>();

    public void StartPick() {
        if (IsPickable()) {
            _PlayerPickup.DoPickUp(hit.transform.gameObject.GetComponent<Item>());
        }
    }
}
