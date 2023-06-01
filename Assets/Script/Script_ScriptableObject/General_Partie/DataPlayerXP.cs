using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataPlayerXP", menuName = "DataPlayerXP", order = 2)]
public class DataPlayerXP : ScriptableObject
{
    [Header("XP Actuel des Compétence Physique")] 
    public float vitalityActualXP;
    public float strenghActualXP;
    public float enduranceActualXP;
    public float speedActualXP;
    
    [Header("XP Actuel des Compétence Primaire")] 
    public float agricultureActualXP;
    public float artisanActualXP;
    public float maçonerieActualXP;
    public float feronnerieActualXP;
    public float electricityActualXP;
    public float mecanicActualXP;
    public float medicineActualXP;
    public float survivalistActualXP; 
    public float socialActualXP;
    public float cookingActualXP;
    public float hackingActualXP; 
    public float intellectActualXP; 
    
    [Header("Compétence Secondaire")] 
    public float mentalBreakActualXP;
    public float visionActualXP;
    public float shootingActualXP;
    public float reloadingActualXP;
}
