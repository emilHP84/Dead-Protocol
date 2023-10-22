using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regen : MonoBehaviour {
    private PlayerManager _playerManager;
    public BodyDamageSystem bodyDamageSystem;

    private float MaxHealth;

    private float timeEndu,timeHunger,timeThurst = 0;
    
    private void Awake() {
        _playerManager = GetComponent<PlayerManager>();
    }

    private void FixedUpdate() {
        timeHunger += Time.deltaTime;
        timeThurst += Time.deltaTime;
        
        if (!Input.GetButton("LeftShift")) {
            timeEndu += Time.deltaTime;
        }
    }
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.A)) Life();
        if (!Input.GetButton("LeftShift")) Endurance();
        Hunger();
        Thurst();
    }
    
    public void Life(){
        bodyDamageSystem.WasHurt();
        _playerManager.dataPlayerCompetence.basicLife -= bodyDamageSystem.damageDefined.damageTake;

    }

    public void Endurance() {
        if (timeEndu >= _playerManager.xpSystem.enduranceTimeDelay && _playerManager.dataPlayerCompetence.basicEndurance < 100) {
            _playerManager.dataPlayerCompetence.basicEndurance += 1;
            timeEndu = 0;
        }
    }
    
    public void Hunger() {
        if (timeHunger >= 10) {
            _playerManager.dataPlayerCompetence.basicHungers -= 1;
            timeHunger = 0;
        }
    }
    
    public void Thurst() {
        if (timeThurst >= 10) {
            _playerManager.dataPlayerCompetence.basicThurst -= 1;
            timeThurst = 0;
        }
    }
}
