using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UiIventory : MonoBehaviour {
    [SerializeField] private GameObject InventoryPanel;
    [Header(" transform Dotween")]
    [SerializeField] private Transform mid, left, right, button;

    private bool inventoryIsOpen;

    private bool isActive = false;
    private float scaleValue = 0;

    private void Start() {
        PlayerUsing.InventoryInput += UIInventory;
        InventoryPanel.SetActive(false);
    }

    private void UIInventory() {
        if (!isActive) scaleValue = 1f;
        else if (isActive) scaleValue = 0f;
        StartCoroutine(GameUI());
    }

    IEnumerator GameUI() {
        button.DOScale(scaleValue, 0.1f);
        left.DOScale(scaleValue, 0.2f);
        mid.DOScale(scaleValue, 0.3f);
        right.DOScale(scaleValue, 0.4f);
        PlayerInventory.instance.CloseActionPanel();
        
        isActive = !isActive;
        if (right.transform.localScale == new Vector3(0,0,0)) CloseInventory();
        if(isActive)OpenInventory();
        yield return null;
    }

    public void OpenInventory(){
        InventoryPanel.SetActive(true);
    }

    public void CloseInventory() {
        InventoryPanel.SetActive(false);
        ToolTipSystem.instance.Hide();
    }
}
