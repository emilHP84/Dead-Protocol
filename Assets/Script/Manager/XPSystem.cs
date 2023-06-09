using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPSystem : MonoBehaviour
{
    public DataPlayerXP _playerXP ;
    public DataPlayerCompetence _playerCompetence;

    private float time;
    [SerializeField] private float dailyXpTime = 3;
    [SerializeField] private float xpAmmount;

    public void Start() {
        time = 0;
    }

    void Update() {
        time += Time.deltaTime;
        if (time >= dailyXpTime) {
            _playerXP.agricultureActualXP += xpAmmount;
            time = 0;
        }
    }
}
