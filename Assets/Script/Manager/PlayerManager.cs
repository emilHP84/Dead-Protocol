using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public DataPlayerCompetence dataPlayerCompetence;

    [Header("Player Transform")]
    public Transform PlayerTransform;

    [Header("vitesse déplacement")]
    public float run;
    public float snick;
    public float walk;
    
    void Start() {
        CalculCompétence();
    }

    void CalculCompétence() {
        walk = dataPlayerCompetence.speed / 5;
        run =  dataPlayerCompetence.speed / 2;
        snick =dataPlayerCompetence.speed / 7;
    }
}
