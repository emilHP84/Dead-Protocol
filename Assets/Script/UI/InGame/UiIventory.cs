using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UiIventory : MonoBehaviour {
    [SerializeField] private GameObject InventoryPanel;
    [Header(" transform Dotween")]
    [SerializeField] private Transform mid, left, right, button;

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
        
        isActive = !isActive;
        
        if (scaleValue == 0) yield return new WaitForSeconds(0.4f);
        InventoryPanel.SetActive(!InventoryPanel.activeSelf);

        yield return null;
    }

    public void CloseInventory() {
        InventoryPanel.SetActive(false);
    }
}
