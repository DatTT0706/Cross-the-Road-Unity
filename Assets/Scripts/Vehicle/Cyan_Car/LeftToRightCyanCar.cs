using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftToRightCyanCar : Car
{
    public LeftToRightCyanCar()
    {
        carPrefab = Resources.Load("Prefabs/LeftToRightGreenCar") as GameObject;
    }

    
}
