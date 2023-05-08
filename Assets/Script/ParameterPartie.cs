using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "PlayerCompetenceParameter", order = 1)]
public class ParameterPartie : ScriptableObject
{
    [Header("paramètre joueurs")] 
    public int basicLife = 100;
    public int basicEndurance = 100; // endurance basic
    public int basicHungers = 100;
    public int basicThurst = 100;

    [Header("Compétence Physique")] 
    public int vitality;
    public int strengh;
    public int endurance;
    public int speed;
    
    [Header("Compétence Primaire")] 
    public int agriculture; // food
    public int artisan; //craft
    public int maçonerie; // construction
    
    public int feronnerie; // craft+ & construction+ 
    public int electricity; // courant electrique & alimentation
    public int mecanic; // réparation véhicule + machine
    
    public int medicine; // soin
    public int survivalist; // survivabilité + ajout craft et construction;
    public int social; //vente & contact pnj

    public int cooking; // cuisine
    public int hacking; // hacker les porte electronique & portes bunker ect...
    public int intellect; // gain d'xp & limite d'apprentissage & apprend au autre
    
    [Header("Compétence Secondaire")] 
    public int mentalBreak = 100;
    public int vision;
    public int shooting;
    public int reloading;




}
   
