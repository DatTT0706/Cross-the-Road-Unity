using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightToLeftCyanCar : Car
{
    public RightToLeftCyanCar()
    {
        carPrefab = Resources.Load("Prefabs/RightToLeftGreenCar") as GameObject;
    }
}
