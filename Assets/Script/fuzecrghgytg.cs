using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuzecrghgytg : MonoBehaviour
{


    public float InitialSpeed;
    private float Speed;
    
    public float Pourc;
    private float PourcSpeed;
    
    public float TimeToResearch = 60;
    public float time;

    public void Start() {
        PourcSpeed = InitialSpeed * Pourc / 100;
        Speed = InitialSpeed;
    }

    public void MoreSpeedOne() {
        Speed += PourcSpeed ;
    }

    public void MoreAttack() {
        
    }

    public void MoreLife() {
        
    }
    
    
    void Update() {
        time += Time.deltaTime;
        MoreSpeedOne();
        Debug.Log(Speed);
    }
}
