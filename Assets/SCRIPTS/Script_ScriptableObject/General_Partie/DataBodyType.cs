using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataBodyType", menuName = "DataBodyType", order = 4)]
public class DataBodyType : ScriptableObject {
    
    public List<ScriptableObject> HurtList;
    public string bodyName;
}
