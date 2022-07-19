using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftToRightRedCar : Car
{
    public LeftToRightRedCar()
    {
        carPrefab = Resources.Load("Prefabs/LeftToRightRedCar") as GameObject;
    }
}
