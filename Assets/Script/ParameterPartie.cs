using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class ParameterPartie : ScriptableObject
{
   [Header("paramètre joueurs")] 
   public int basicLife;
   public int basicEndurance;
   public float basicSpeed;
   public int basicDamage;
   public int basicResistance;
}
