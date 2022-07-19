using Assets.Scripts.Vehicle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFactory : MonoBehaviour, ICarFactory
{

    public GameObject endPoint;
    public List<Car> cars;

    public Car buildBlueCar(Vector3 startPoint, Vector3 endPoint)
    {
        Car car;
        if (startPoint.x < endPoint.x)
        {
            car = new LeftToRightBlueCar();
        }
        else
        {
            car = new RightToLeftBlueCar();
        }

        buildGeneralCar(startPoint, endPoint, car);
        return car;
    }

    public Car buildCyanCar(Vector3 startPoint, Vector3 endPoint)
    {
        Car car;
        if (startPoint.x < endPoint.x)
        {
            car = new LeftToRightCyanCar();
        }
        else
        {
            car = new RightToLeftCyanCar();
        }
        buildGeneralCar(startPoint, endPoint, car);
        return car;
    }

    public Car buildGreyCar(Vector3 startPoint, Vector3 endPoint)
    {
        Car car;
        if (startPoint.x < endPoint.x)
        {
            car = new LeftToRightGreyCar();
        }
        else
        {
            car = new RightToLeftGreyCar();
        }
        buildGeneralCar(startPoint, endPoint, car);
        return car;
    }

    public Car buildOrangeCar(Vector3 startPoint, Vector3 endPoint)
    {
        Car car;
        if (startPoint.x < endPoint.x)
        {
            car = new LeftToRightOrangeCar();
        }
        else
        {
            car = new RightToLeftOrangeCar();
        }
        buildGeneralCar(startPoint, endPoint, car);
        return car;
    }

    public Car buildRedCar(Vector3 startPoint, Vector3 endPoint)
    {
        Car car;
        if (startPoint.x < endPoint.x)
        {
            car = new LeftToRightRedCar();
        }
        else
        {
            car = new RightToLeftRedCar();
        }
        buildGeneralCar(startPoint, endPoint, car);
        return car;
    }

    public Car buildTealCar(Vector3 startPoint, Vector3 endPoint)
    {
        Car car;
        if (startPoint.x < endPoint.x)
        {
            car = new LeftToRightTealCar();
        }
        else
        {
            car = new RightToLeftTealCar();
        }
        buildGeneralCar(startPoint, endPoint, car);
        return car;
    }

    private static void buildGeneralCar(Vector3 startPoint, Vector3 endPoint, Car car)
    {
        Debug.Log(car.CarPrefab);
        var creepPortal = Instantiate(
            car.CarPrefab,
            startPoint,
            Quaternion.identity
        );
        creepPortal.AddComponent<Car>();
        creepPortal.GetComponent<Car>().endLoc = endPoint;
    }

    // Start is called before the first frame update
    void Start()
    {

        //this.buildBlueCar(gameObject.transform.position, endPoint.transform.position);
        //this.buildCyanCar(gameObject.transform.position, endPoint.transform.position);
        //this.buildGreyCar(gameObject.transform.position, endPoint.transform.position);
        //this.buildOrangeCar(gameObject.transform.position, endPoint.transform.position);
        //this.buildRedCar(gameObject.transform.position, endPoint.transform.position);
        //this.buildTealCar(gameObject.transform.position, endPoint.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
