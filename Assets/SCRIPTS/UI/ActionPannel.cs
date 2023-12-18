using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPannel : MonoBehaviour
{
    public static ActionPannel instance;

    [Header("Action Panel references ")]
    [SerializeField] private GameObject actionPannel;
    [SerializeField] private GameObject UseButton, EquipButton, DropButton, ScrapButton;

    private ItemData itemCurrentlySelected;

    private void OnEnable(){
        Inventory.PannelMustClose += CloseActionPanel;

    }
    private void OnDisable(){
        Inventory.PannelMustClose -= CloseActionPanel;
    }

    private void Start(){
        gameObject.transform.DOScale(0, 0);
    }
    public void OpenActionPanel(ItemData item, Vector3 slotPosition){
        itemCurrentlySelected = item;
        actionPannel.transform.DOScale(1, 0.2f);
        if (item == null) return;
        switch (item.typeOfItem)
        {
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

        actionPannel.transform.position = slotPosition;
        actionPannel.SetActive(true);
    }

    public void CloseActionPanel()
    {
        actionPannel.transform.DOScale(0, 0.2f);
        actionPannel.SetActive(false);
        itemCurrentlySelected = null;
    }

  
}
