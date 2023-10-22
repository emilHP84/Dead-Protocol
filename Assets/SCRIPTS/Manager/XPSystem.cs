using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class XPSystem : MonoBehaviour { 
    private float timeEndu, timeSpeed;
    public float enduranceTimeDelay;
    
    public DataPlayerXP dataPlayerXp ;
    public DataPlayerCompetence dataPlayerCompetence;

    private float time;

    public void Start() {
        time = 0;
    }

    void Update() {
        timeEndu += Time.deltaTime;
        timeSpeed += Time.deltaTime;
    }

    public void xpSpeed() {
        if (timeSpeed >= 1) {
            dataPlayerXp.speedActualXP += 0.01f;
            timeSpeed = 0;
        }
    }

    public void xpEndurance() {
        if (timeEndu >= enduranceTimeDelay) {
            dataPlayerCompetence.basicEndurance -= 1;
            dataPlayerXp.enduranceActualXP += 0.01f;
            timeEndu = 0;
        }
    }
}
