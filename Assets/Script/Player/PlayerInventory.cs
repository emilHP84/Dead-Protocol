using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {
    public static PlayerInventory instance;
    [SerializeField] private List<ItemData> contentInventory = new List<ItemData>();
    [SerializeField] private Transform InventorySlotsParent;
    [SerializeField] private int basicInventorySlot = 24;
    [SerializeField] private Sprite emptySlotVisual;

    [Header("Action Panel references ")]
    [SerializeField] private GameObject ActionPannel;
    [SerializeField] private GameObject UseButton, EquipButton, DropButton, ScrapButton;
    [SerializeField] private Transform dropPoint;
    
    private ItemData itemCurrentlySelected;

    public void Awake() {
        instance = this;
    }
    
    public void Start() {
        RefreshContent();
        ActionPannel.transform.DOScale(0, 0);
    }
    
    public void AddItem(ItemData item) {
        contentInventory.Add(item);
        RefreshContent();
    }

    private void RefreshContent() {
        for (int i = 0; i < InventorySlotsParent.childCount; i++) {
            Slot currentSlot = InventorySlotsParent.GetChild(i).GetComponent<Slot>();
            currentSlot.item = null;
            currentSlot.itemVisual.sprite = emptySlotVisual;
        }
        for (int i = 0; i < contentInventory.Count; i++) {
            Slot currentSlot = InventorySlotsParent.GetChild(i).GetComponent<Slot>();
            currentSlot.item = contentInventory[i];
                currentSlot.itemVisual.sprite = contentInventory[i].visualItem;
        }
    }

    public bool Isfull() {
        return basicInventorySlot == contentInventory.Count;
    }
    
    

    public void OpenActionPanel(ItemData item, Vector3 slotPosition) {
        itemCurrentlySelected = item;
        ActionPannel.transform.DOScale(1, 0.2f);
        if (item == null) return;
        switch (item.typeOfItem) {
            case TypeOfItem.component:
                UseButton.SetActive(false);
                EquipButton.SetActive(false);
                break;
            
            case TypeOfItem.Outfit:
                UseButton.SetActive(false);
                EquipButton.SetActive(true);
                break;
            case TypeOfItem.armor:
                UseButton.SetActive(false);
                EquipButton.SetActive(true);
                break;
            case TypeOfItem.bagpack:
                UseButton.SetActive(false);
                EquipButton.SetActive(true);
                break;
            case TypeOfItem.MeleeWeapon:
                UseButton.SetActive(false);
                EquipButton.SetActive(true);
                break;
            case TypeOfItem.RangeWeapon:
                UseButton.SetActive(false);
                EquipButton.SetActive(true);
                break;
            
            case TypeOfItem.food:
                UseButton.SetActive(true);
                EquipButton.SetActive(false);
                break;
            case TypeOfItem.medicine:
                UseButton.SetActive(true);
                EquipButton.SetActive(false);
                break;
            case TypeOfItem.structure:
                UseButton.SetActive(true);
                EquipButton.SetActive(false);
                break;
        }

        ActionPannel.transform.position = slotPosition;
        ActionPannel.SetActive(true);
    }

    public void CloseActionPanel() {
        ActionPannel.transform.DOScale(0, 0.2f);
        ActionPannel.SetActive(false);
        itemCurrentlySelected = null;
    }
    
    

    public void UseActionButton() {
        
        CloseActionPanel();
    }

    public void EquipActionButton() {
        
        CloseActionPanel();
    }

    public void DropActionButton() {
        GameObject instantiateditem = Instantiate(itemCurrentlySelected.prefabItem);
        instantiateditem.transform.position = dropPoint.position;
        contentInventory.Remove(itemCurrentlySelected);
        RefreshContent();
        CloseActionPanel();
    }

    public void ScrapActionButton() {
        contentInventory.Remove(itemCurrentlySelected);
        RefreshContent();
        CloseActionPanel();
    }
}
