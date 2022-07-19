using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftToRightTealCar : Car
{
    public LeftToRightTealCar()
    {
        carPrefab = Resources.Load("Prefabs/LeftToRightTealCar") as GameObject;
    }
}
