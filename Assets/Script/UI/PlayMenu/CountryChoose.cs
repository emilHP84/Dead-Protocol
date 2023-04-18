using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CountryChoose : MonoBehaviour {
    public TMP_Text texting;

    private void Start() {
        texting.text = " ";
    }

    public void Japon() {
        texting.text = "pays insulaire de l'Asie de l'Est, le Japon est un pays bien dévellopé sur des iles volcanique, souvent pris en proie par de violent séisme ";
    }
    
}
