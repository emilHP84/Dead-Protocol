using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuUI : MonoBehaviour {
    [Header("rect transform UI:")]
    public RectTransform MainUi;
    public RectTransform MenuSetting;
    
    [Header("CanvasGroup UI:")]
    public CanvasGroup canvasMainUI;
    public CanvasGroup canvasSettingUI;
    
    [Header("parameter UI:")]
    public float moveTime;
    public float fadeTime;

    public void Start() {
        MenuSetting.transform.DOScale(0.75f, 0);
        MenuSetting.DOAnchorPos(new Vector2(0, -1080),0,false);
        canvasMainUI.alpha = 1f;
    }
    
    
    public void SwitchToSetting() {
        MainUi.DOAnchorPos(new Vector2(-300, 0), moveTime, false); //.SetEase(Ease.OutElastic);
        canvasMainUI.DOFade(0, fadeTime);
        
        MenuSetting.transform.DOScale(1, moveTime);
        MenuSetting.DOAnchorPos(new Vector2(0, 0),moveTime,false);
        canvasSettingUI.DOFade(1, fadeTime);
    }

    public void SwitchToMainUI() {
        MainUi.DOAnchorPos(new Vector2(0, 0), moveTime, false); //.SetEase(Ease.OutElastic);
        canvasMainUI.DOFade(1, fadeTime);

        MenuSetting.transform.DOScale(0.75f, moveTime);
        MenuSetting.DOAnchorPos(new Vector2(0, -1080),moveTime,false);
        canvasSettingUI.DOFade(0, fadeTime);
    }

}
