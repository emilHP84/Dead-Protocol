using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Item/New Item")]
public class ItemData : ScriptableObject
{
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
public enum EquipementType{nothing, helmet, face, neck, neckless, TShirt, shirt, jacket, BulletproofVest, bag, belt, olsterOne, olsterTwo, pants, boots, protection}
public enum Rarity{ worn, common, unusal, rare, epic, legendary}

