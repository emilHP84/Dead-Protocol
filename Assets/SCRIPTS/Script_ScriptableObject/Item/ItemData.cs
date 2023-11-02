using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Item/New Item")]
public class ItemData : ScriptableObject{
    public TypeOfItem typeOfItem;
    public Rarity rarity;
    public EquipementType equipementType;
    public string itemName;
    public string itemDescription;
    public Sprite visualItem;
    public GameObject prefabItem;
    public float kilogramme;
}
public enum TypeOfItem{ equipement, weapon, food, medicine, component, structure};
[HideInInspector] public enum EquipementType{nothing, helmet, face, neck, neckless, shirt, jacket, BulletproofVest, bag, belt, olster, pants, boots, protection}
[HideInInspector] public enum Rarity{ worn, common, unusal, rare, epic, legendary}



#if UNITY_EDITOR


[CustomEditor(typeof(ItemData))]
public class ItemdataEditor : Editor { 
    public override void OnInspectorGUI(){
        ItemData item = (ItemData)target;

        if(item.typeOfItem == TypeOfItem.equipement){
             
        }

        base.OnInspectorGUI();
    }
}

#endif