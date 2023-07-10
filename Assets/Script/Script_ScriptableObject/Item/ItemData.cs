using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/New Item")]
public class ItemData : ScriptableObject {
    public string name;
    public Sprite visualItem;
    public GameObject prefabItem;
    public float kilogramme;
}
