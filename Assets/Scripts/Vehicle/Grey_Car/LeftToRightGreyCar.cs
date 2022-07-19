using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftToRightGreyCar : Car
{
    public LeftToRightGreyCar()
    {
        carPrefab = Resources.Load("Prefabs/LeftToRightGrayCar") as GameObject;
    }
    
}
