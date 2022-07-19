using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightToLeftOrangeCar : Car
{
    public RightToLeftOrangeCar()
    {
        carPrefab = Resources.Load("Prefabs/RightToLeftOrangeCar") as GameObject;
    }
}
