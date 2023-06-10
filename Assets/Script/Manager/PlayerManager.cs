using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public DataPlayerCompetence dataPlayerCompetence;

    [Header("vitesse déplacemnt")]
    public float run;
    public float snick;
    public float walk;
    
    void Start() {
        CalculCompétence();
    }
    
    void Update() {
        
    }

    void CalculCompétence() {
        walk = dataPlayerCompetence.speed / 5;
        run =  dataPlayerCompetence.speed / 2;
        snick =dataPlayerCompetence.speed / 7;
    }
}
