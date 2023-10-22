using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Inventory : MonoBehaviour {
    public static Inventory instance;
    
    [Header("inventory refrences")]
    [SerializeField] private List<ItemData> contentInventory = new List<ItemData>();
    [SerializeField] private EquipementLibrary equipementLibrary;
    [SerializeField] private Transform InventorySlotsParent;
    [SerializeField] private int basicInventorySlot = 24;
    [SerializeField] private Sprite emptySlotVisual;

    [Header("Action Panel references ")]
    [SerializeField] private GameObject ActionPannel;
    [SerializeField] private GameObject UseButton, EquipButton, DropButton, ScrapButton;
    [SerializeField] private Transform dropPoint;

    [Header("equipement references")]
    [SerializeField] private List<ItemData> protectionEquip = new List<ItemData>();
    [SerializeField] private List<ItemData> bottomEquip = new List<ItemData>();
    [SerializeField] private List<ItemData> headEquip = new List<ItemData>();
    [SerializeField] private List<ItemData> topEquip = new List<ItemData>();
    [SerializeField] private Transform headSlotParent, topSlotParent, bottomSlotParent, protectionSlotParent;


    private ItemData itemCurrentlySelected;

    public void Awake() {
        instance = this;
    }
    
    public void Start() {
        RefreshContent();
        RefreshEquipementContent();
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
            
            case TypeOfItem.equipement:
                UseButton.SetActive(false);
                EquipButton.SetActive(true);
                break;
            case TypeOfItem.weapon:
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
        if (itemCurrentlySelected != null && itemCurrentlySelected.equipementType != EquipementType.nothing){
            if(itemCurrentlySelected.equipementType == EquipementType.helmet || itemCurrentlySelected.equipementType == EquipementType.face || itemCurrentlySelected.equipementType == EquipementType.neck || itemCurrentlySelected.equipementType == EquipementType.neckless){
                headEquip.Add(itemCurrentlySelected);
                Instantiate(itemCurrentlySelected.prefabItem);

                contentInventory.Remove(itemCurrentlySelected);
            }
            if (itemCurrentlySelected.equipementType == EquipementType.shirt || itemCurrentlySelected.equipementType == EquipementType.jacket || itemCurrentlySelected.equipementType == EquipementType.BulletproofVest || itemCurrentlySelected.equipementType == EquipementType.bag)
            {
                topEquip.Add(itemCurrentlySelected);
                Instantiate(itemCurrentlySelected.prefabItem);

                contentInventory.Remove(itemCurrentlySelected);
            }
            if (itemCurrentlySelected.equipementType == EquipementType.belt || itemCurrentlySelected.equipementType == EquipementType.olster || itemCurrentlySelected.equipementType == EquipementType.pants || itemCurrentlySelected.equipementType == EquipementType.boots)
            {
                bottomEquip.Add(itemCurrentlySelected);
                Instantiate(itemCurrentlySelected.prefabItem);

                contentInventory.Remove(itemCurrentlySelected);
            }
            if (itemCurrentlySelected.equipementType == EquipementType.protection)
            {
                protectionEquip.Add(itemCurrentlySelected);
                Instantiate(itemCurrentlySelected.prefabItem);

                contentInventory.Remove(itemCurrentlySelected);
            }
        }
        contentInventory.Remove(itemCurrentlySelected);
        RefreshEquipementContent();
        CloseActionPanel();
    }

    private void RefreshEquipementContent()
    {
        for (int i = 0; i < headEquip.Count; i++)
        {
            Slot currentSlot = headSlotParent.GetChild(i).GetComponent<Slot>();
            currentSlot.item = headEquip[i];
            currentSlot.itemVisual.sprite = headEquip[i].visualItem;
        }
        for (int i = 0; i < topEquip.Count; i++)
        {
            Slot currentSlot = topSlotParent.GetChild(i).GetComponent<Slot>();
            currentSlot.item = topEquip[i];
            currentSlot.itemVisual.sprite = topEquip[i].visualItem;
        }
        for (int i = 0; i < bottomEquip.Count; i++)
        {
            Slot currentSlot = bottomSlotParent.GetChild(i).GetComponent<Slot>();
            currentSlot.item = bottomEquip[i];
            currentSlot.itemVisual.sprite = bottomEquip[i].visualItem;
        }
        for (int i = 0; i < protectionEquip.Count; i++)
        {
            Slot currentSlot = protectionSlotParent.GetChild(i).GetComponent<Slot>();
            currentSlot.item = protectionEquip[i];
            currentSlot.itemVisual.sprite = protectionEquip[i].visualItem;
        }
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
