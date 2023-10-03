using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataDamageType", menuName = "DataDamageType", order = 3)]
public class DataDamageType : ScriptableObject{
    
    public string name;
    public int damageTake;
    
    [Range(1, 5)] 
    public int hurtGravity;
}
