using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class ParameterPartie : ScriptableObject
{
   [Header("paramètre joueurs")] 
   public float basicSpeed;

   public int basicLife;
}
