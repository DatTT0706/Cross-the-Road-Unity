using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightToLeftGreyCar : Car
{
    public RightToLeftGreyCar()
    {
        carPrefab = Resources.Load("Prefabs/RightToLeftGrayCar") as GameObject;
    }
}
