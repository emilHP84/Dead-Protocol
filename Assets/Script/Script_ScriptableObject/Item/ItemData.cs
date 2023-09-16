using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Item/New Item")]
public class ItemData : ScriptableObject
{
    public TypeOfItem typeOfItem;
    public Rarity rarity;
    public string itemName;
    public string itemDescription;
    public Sprite visualItem;
    public GameObject prefabItem;
    public float kilogramme;
}
public enum TypeOfItem{ Outfit, armor, bagpack, MeleeWeapon, RangeWeapon, food, medicine, component, structure};
public enum Rarity{ worn, common, unusal, rare, epic, legendary}

