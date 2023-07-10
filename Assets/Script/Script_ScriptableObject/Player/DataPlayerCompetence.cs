using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataPlayerCompétence", menuName = "DataPlayerCompétence", order = 1)]
public class DataPlayerCompetence : ScriptableObject {
    
    [Header("paramètre joueurs")] 
    public int basicLife = 100;
    public int basicEndurance = 100; 
    public int basicHungers = 100;
    public int basicThurst = 100;

    [Header("Compétence Physique")] 
    public int vitality = 5;
    public int strengh = 5;
    public int endurance = 5;
    public float speed = 5;
    
    [Header("Compétence Primaire")] 
    public int agriculture;
    public int artisan; 
    public int maçonerie; 
    
    public int feronnerie; 
    public int electricity; 
    public int mecanic; 
    
    public int medicine; 
    public int survivalist; 
    public int social;

    public int cooking; 
    public int hacking; 
    public int intellect = 5; 
    
    [Header("Compétence Secondaire")] 
    public int mentalBreak = 100;
    public int vision;
    public int shooting;
    public int reloading;
}
   
