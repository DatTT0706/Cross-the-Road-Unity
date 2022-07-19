using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightToLeftBlueCar: Car
{
    public RightToLeftBlueCar()
    {
        carPrefab = Resources.Load("Prefabs/RightToLeftBlueCar") as GameObject;
    }
}
