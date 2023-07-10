using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
    [SerializeField] private List<ScriptableObject> contentInventory = new List<ScriptableObject>();

    public void AddItem(ScriptableObject item) {
        contentInventory.Add(item);
    }
    
}
