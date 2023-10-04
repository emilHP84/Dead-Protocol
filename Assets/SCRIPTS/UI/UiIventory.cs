using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UiIventory : MonoBehaviour {
     // partit du script pour l'animation de l'inventaire//
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    [SerializeField] private GameObject InventoryPanel;
    
    [Header(" transform Dotween")]
    [SerializeField] private GameObject mid, left, right, button;

    private bool inventoryIsOpen;

    private bool isActive = false;
    private float scaleValue = 0;

    private void Start() {
        PlayerUsing.InventoryInput += UIInventory;
        InventoryPanel.SetActive(false);
        ScrollCheck();
    }

    private void UIInventory() {
        if (!isActive) scaleValue = 1f;
        else if (isActive) scaleValue = 0f;
        StartCoroutine(GameUI());
    }

    IEnumerator GameUI() {
        button.transform.DOScale(scaleValue, 0.1f);
        left.transform.DOScale(scaleValue, 0.2f);
        mid.transform.DOScale(scaleValue, 0.3f);
        right.transform.DOScale(scaleValue, 0.4f);
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

    // partit du script pour le slider de l'inventaire//
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    [Header("slider for inventory")]
    [SerializeField] private RectTransform original;
    [SerializeField] private ScrollRect scrollrect;
    [SerializeField] private Slider slider;

    public void ScrollCheck(){
        if(original.transform.position == new Vector3(0,0,0)){
            Debug.Log("test");
        }
    }

}
