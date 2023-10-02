using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipementLibrary : MonoBehaviour{
    public List<EquipementLIbraryItem> content = new List<EquipementLIbraryItem>();
}

[System.Serializable]
public class EquipementLIbraryItem{
    public ItemData itemData;
    public GameObject itemPrefab;
}