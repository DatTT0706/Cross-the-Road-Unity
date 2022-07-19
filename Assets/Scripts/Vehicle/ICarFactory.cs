using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Vehicle
{
    public interface ICarFactory
    {
        Car buildRedCar(Vector3 startPoint, Vector3 endPoint, float speed);
        Car buildBlueCar(Vector3 startPoint, Vector3 endPoint, float speed);
        Car buildCyanCar(Vector3 startPoint, Vector3 endPoint, float speed);
        Car buildGreyCar(Vector3 startPoint, Vector3 endPoint, float speed);
        Car buildOrangeCar(Vector3 startPoint, Vector3 endPoint, float speed);
        Car buildTealCar(Vector3 startPoint, Vector3 endPoint, float speed);
    }
}
