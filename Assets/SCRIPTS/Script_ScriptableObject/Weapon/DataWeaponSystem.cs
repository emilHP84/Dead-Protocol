using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/automatic", order = 5)]
public class DataWeaponSystem : ScriptableObject { 
    [Header("info")] 
    public new string name;
    
    [Header("Particularity")]
    public bool burstModule;
    
    [Header("Shooting")]
    public int Damage;
    public float fireRate;
    public float MaxDistanceHit;

    [Header("Reloading")] 
    public int currentAmmo;
    public int maxSizeAmmo;
    public int reloadTime;
    public bool reloading;

    [Header("precision")] 
    public float precision;
    public float recul;




}
