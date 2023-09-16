using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mime;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class PlayerStartPickup : MonoBehaviour {
    
    // inventory variable
    public PlayerPickup _PlayerPickup;
    [SerializeField]private float pickupRange;
    private RaycastHit hit;
    [SerializeField]private LayerMask layerMask;

    // E interact
    [SerializeField] private Transform pickupText;
    [SerializeField]private Text itemName;
    
    private void Start() {
        PlayerUsing.InteractInput += StartPick;
        pickupText.DOScale(0, 0.1f);
    }

    private bool IsPickable() => Physics.Raycast(transform.position, transform.forward, out hit, pickupRange, layerMask) &&
                                 hit.transform.GetComponent<Item>();

    public void StartPick() {
        if (IsPickable()) {
            _PlayerPickup.DoPickUp(hit.transform.gameObject.GetComponent<Item>());
        }
    }

    public void Update() {
        if (IsPickable()) {
            pickupText.DOScale(1,0.1f);
            itemName.text = hit.transform.gameObject.GetComponent<Item>().item.itemName;
        }
        else pickupText.DOScale(0,0.1f);
    }
}
