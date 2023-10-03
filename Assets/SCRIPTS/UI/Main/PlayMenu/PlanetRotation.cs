using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
   private float _speed = 1.5f;
   
    void Update() {
        gameObject.transform.Rotate(1* _speed * Time.deltaTime, 1 * _speed * Time.deltaTime, 0);
    }
}
