using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public XPSystem xpSystem;
    public DataPlayerCompetence dataPlayerCompetence;

    [Header("vitesse déplacement")]
    public static float run;
    public static float snick;
    public static float walk;
    
    
    [Header("Booléen")] 
    public bool boostedAIM = false;
    public bool boostedUI = false;

    void Start() {
        CalculCompétence();
    }
    
    void CalculCompétence() {
        snick = dataPlayerCompetence.speed / 7;
        walk = dataPlayerCompetence.speed / 5;
        run = dataPlayerCompetence.speed / 2;
        xpSystem.enduranceTimeDelay = dataPlayerCompetence.endurance / 5;
    }
}
