
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("boutton Main UI:")]
    public Transform transformButton;
    [Header("panel UI:")] 
    public GameObject gameobjectButton;
    
    public void OnPointerEnter(PointerEventData eventData) {
        transformButton.DOScale(1.5f, 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData) {
        transformButton.DOScale(1, 0.5f);
    }
}
