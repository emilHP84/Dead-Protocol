using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TweenButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    
    private Transform transformButton;
    public float scale;

    public void Awake() {
        transformButton = gameObject.transform;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        transformButton.DOScale(scale, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData) {
        transformButton.DOScale(1, 0.3f);
    }
}
