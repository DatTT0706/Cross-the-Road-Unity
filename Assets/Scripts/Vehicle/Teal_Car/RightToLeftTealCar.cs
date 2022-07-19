using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightToLeftTealCar : Car
{
    public RightToLeftTealCar()
    {
        carPrefab = Resources.Load("Prefabs/RightToLeftTealCar") as GameObject;
    }
}
