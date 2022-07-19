using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightToLeftRedCar : Car
{
    public RightToLeftRedCar()
    {
        carPrefab = Resources.Load("Prefabs/RightToLeftRedCar") as GameObject;
    }
}
