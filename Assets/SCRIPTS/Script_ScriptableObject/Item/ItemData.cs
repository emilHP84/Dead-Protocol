using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

[CreateAssetMenu(fileName = "Item", menuName = "Item/New Item")]
public class ItemData : ScriptableObject{
    public TypeOfItem typeOfItem;
    public Rarity rarity;
    [HideInInspector] public EquipementType equipementType;
    public string itemName;
    public string itemDescription;
    public Sprite visualItem;
    public GameObject prefabItem;
    public float kilogramme;
}
public enum TypeOfItem{ equipement, weapon, food, medicine, component, structure};
 public enum EquipementType{nothing, helmet, face, neck, neckless, shirt, jacket, BulletproofVest, bag, belt, olster, pants, boots, protection}
 public enum Rarity{ worn, common, unusal, rare, epic, legendary}



#if UNITY_EDITOR


[CustomEditor(typeof(ItemData))]
public class ItemDataEditor : Editor { 
    public override void OnInspectorGUI(){
        ItemData item = (ItemData)target;

        if (item.typeOfItem == TypeOfItem.equipement){
            SerializedProperty equipementType = serializedObject.FindProperty("equipementType");
            EditorGUILayout.PropertyField(equipementType);
        }

        serializedObject.ApplyModifiedProperties();
        base.OnInspectorGUI();
    }
}

#endif