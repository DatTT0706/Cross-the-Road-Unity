using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    protected GameObject carPrefab;
    protected float carSpeed;
    public Vector3 startLoc;
    public Vector3 endLoc;

    public GameObject CarPrefab
    {
        get { return carPrefab; }
    }
    void Start()
    {
        carSpeed = 5;
        startLoc = gameObject.transform.position;
        
    }

    void Update()
    {
        float moveLim = carSpeed * Time.deltaTime;        
        transform.position = Vector3.MoveTowards(transform.position, endLoc, moveLim);
    }
}
