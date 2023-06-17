using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldManager {
    [Range(-1,1)] public static float DayOrNight;
    [Range(1, 5)] public static float météo;

    public  static float timeSpawnning;
    
    public static float gravity = -9.81f;
    
}
