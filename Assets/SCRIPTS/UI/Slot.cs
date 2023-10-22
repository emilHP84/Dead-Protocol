using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    public ItemData item;
    public Image itemVisual;
    
    public void OnPointerEnter(PointerEventData eventData) {
        if (item != null) {
            ToolTipSystem.instance.StartCoroutine
                (ToolTipSystem.instance.Show(item.itemDescription, item.itemName));
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        ToolTipSystem.instance.StartCoroutine
            (ToolTipSystem.instance.Hide());
        
    }

    public void OnClickSlot() {
        Inventory.instance.OpenActionPanel(item, transform.position);
    }
}

