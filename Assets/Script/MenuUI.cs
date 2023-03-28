using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuUI : MonoBehaviour {
    public GameObject MenuUIng;
    public GameObject MenuSetting;

    public float time;

    private bool isActive;

    public void Start() {
        MenuSetting.transform.DOMoveY(-20, 1);
        time = 0;
    }

    public void Update() {
        time += Time.deltaTime;
    }

    public void SwitchToSetting() {
        MenuUIng.transform.DOMoveX(3, 1);
        time = 0;
        isActive = true;
        if (time >= 1) {
            MenuUIng.SetActive(false);
            MenuSetting.SetActive(true);
            MenuSetting.transform.DOMoveY(0, 1);
        }
    }

    public void SwitchToMainUI() {
        MenuSetting.transform.DOMoveY(-20, 1);
        time = 0;
        if (time >= 1) {
            MenuSetting.SetActive(false); 
            MenuUIng.SetActive(true);
            MenuUIng.transform.DOMoveX(0, 1);
        }
    }

}
