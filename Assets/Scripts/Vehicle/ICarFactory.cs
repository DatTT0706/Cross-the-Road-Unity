using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Vehicle
{
    internal interface ICarFactory
    {
        Car buildRedCar(Vector3 startPoint, Vector3 endPoint);
        Car buildBlueCar(Vector3 startPoint, Vector3 endPoint);
        Car buildCyanCar(Vector3 startPoint, Vector3 endPoint);
        Car buildGreyCar(Vector3 startPoint, Vector3 endPoint);
        Car buildOrangeCar(Vector3 startPoint, Vector3 endPoint);
        Car buildTealCar(Vector3 startPoint, Vector3 endPoint);
    }
}
