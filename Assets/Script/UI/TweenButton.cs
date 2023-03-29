using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TweenButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("boutton Main UI:")]
    public Transform transformButton;
    public float scale;
    
    public void OnPointerEnter(PointerEventData eventData) {
        transformButton.DOScale(scale, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData) {
        transformButton.DOScale(1, 0.3f);
    }
}
