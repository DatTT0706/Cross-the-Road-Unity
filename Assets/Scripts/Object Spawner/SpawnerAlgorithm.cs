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
    [SerializeField] private CarFactory carFactory;
    // Start is called before the first frame update

    
    void Start()
    {

        StartCoroutine(SpawnObject());
        carFactory = gameObject.GetComponent<CarFactory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnObject() 
    {
        yield return new WaitForSeconds(1);
       
        var startPosition = new GameObject();
        var endPosition = new GameObject();
        int randDirection = Random.Range(0, 10);
        if (randDirection<5)
        {
            startPosition = rightPosition;
            endPosition = leftPosition;
        }
        else
        {
            startPosition = leftPosition;
            endPosition = rightPosition;
        }

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSeperationTime, maxSeperationTime));

            //spawnFactory.SpawnObject(objectSpeed, startPosition, endPosition);

            objectSpeed = 10;
            carFactory.GenerateRandomCar(startPosition.transform.position, endPosition.transform.position, objectSpeed);
        }
       
    }
}

interface SpawnFactory
{
    public GameObject SpawnObject(int speed, GameObject spawnLocation, GameObject destroyLocation);
}