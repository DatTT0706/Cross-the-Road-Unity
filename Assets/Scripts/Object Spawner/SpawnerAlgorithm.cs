using System.Collections;
using UnityEngine;

public class SpawnerAlgorithm : MonoBehaviour
{
    [SerializeField] private SpawnFactory spawnFactory;
    [SerializeField] private int minSeperationTime;
    [SerializeField] private int maxSeperationTime;
    [SerializeField] private GameObject leftPosition;
    [SerializeField] private GameObject rightPosition;
    [SerializeField] private int objectSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnObject() 
    {
        yield return new WaitForSeconds(Random.Range(minSeperationTime,maxSeperationTime));
        var startPosition = new GameObject(); 
        var endPosition = new GameObject();
        if(Random.Range(0,1) == 0)
        {
            startPosition = rightPosition;
            endPosition = leftPosition;
        }
        else
        {
            startPosition = leftPosition;
            endPosition = rightPosition;
        }
        spawnFactory.SpawnObject(objectSpeed, startPosition, endPosition);
    }
}

interface SpawnFactory
{
    public GameObject SpawnObject(int speed, GameObject spawnLocation, GameObject destroyLocation);
}