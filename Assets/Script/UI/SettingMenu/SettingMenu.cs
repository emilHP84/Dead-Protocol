using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingMenu : MonoBehaviour {
    [Header("Scroll Setting UI:")] 
    public GameObject ScrollGraphics;
    public GameObject ScrollSound;
    public GameObject ScrollControl;
    public GameObject Scrolllanguage;

    public void Start() {
        ScrollGraphics.SetActive(true);
        ScrollSound.SetActive(false);
        ScrollControl.SetActive(false);
        Scrolllanguage.SetActive(false);
    }

    public void IsGraphicsScroll() {
        ScrollGraphics.SetActive(true);
        ScrollSound.SetActive(false);
        ScrollControl.SetActive(false);
        Scrolllanguage.SetActive(false);
    }

    public void IsSoundScroll() {
        ScrollGraphics.SetActive(false);
        ScrollSound.SetActive(true);
        ScrollControl.SetActive(false);
        Scrolllanguage.SetActive(false);
    }

    public void IsControlScroll() {
        ScrollGraphics.SetActive(false);
        ScrollSound.SetActive(false);
        ScrollControl.SetActive(true);
        Scrolllanguage.SetActive(false);
    }

    public void IsLanguageScroll() {
        ScrollGraphics.SetActive(false);
        ScrollSound.SetActive(false);
        ScrollControl.SetActive(false);
        Scrolllanguage.SetActive(true);
    }
        
}
