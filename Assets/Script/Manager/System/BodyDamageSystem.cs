using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BodyDamageSystem : MonoBehaviour {
    [Header("Damage")] 
    public List<DataDamageType> damageType = new List<DataDamageType>();
    [Header("BodyPart")] 
    public List<DataBodyType> bodyType = new List<DataBodyType>();
    
    public DataDamageType damageDefined;
    public DataBodyType bodyDefined;
    
    private int RandomHurtNumber;
    private int RandomBodyNumber;
    
    public void WasHurt() {
        RandomDamage();
        RandomBody();
        bodyDefined.HurtList.Add(damageDefined);
    }
 
    private void RandomDamage() { 
        RandomHurtNumber = Random.Range(0,100);
        
        if (RandomHurtNumber >= 0  && RandomHurtNumber <30) damageDefined = damageType[4];
        else if (RandomHurtNumber >= 30 && RandomHurtNumber < 60) damageDefined = damageType[3];
        else if (RandomHurtNumber >= 60 && RandomHurtNumber < 80) damageDefined = damageType[2];
        else if (RandomHurtNumber >= 80 && RandomHurtNumber < 90) damageDefined = damageType[1];
        else if (RandomHurtNumber >= 90 && RandomHurtNumber <= 100) damageDefined = damageType[0];
    }

    private void RandomBody(){
        RandomBodyNumber = Random.Range(0, 16);
        
        int randomBodyNumber = RandomBodyNumber;
        bodyDefined = bodyType[randomBodyNumber];
    }
}