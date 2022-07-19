using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftToRightOrangeCar : Car
{
    public LeftToRightOrangeCar()
    {
        carPrefab = Resources.Load("Prefabs/LeftToRightOrangeCar") as GameObject;
    }
    
}
