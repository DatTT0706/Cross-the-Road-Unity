using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStateListener : MonoBehaviour, StateChangeListener
{
    public GameObject car;
    public CarFactory carFactory;
   
    public void OnActive()
    {
        car.SetActive(true);
    }

    public void OnCharacterStateChanged(ObjectState state)
    {
        switch (state)
        {
            case ObjectState.INITIALIZED:
                break;
            case ObjectState.ACTIVE:
                break;
            case ObjectState.DEACTIVE:
                break;
            case ObjectState.DEAD:
                GameObject.Destroy(car);
                break;
            default:
                break;
        }
    }

    public void OnDeactive()
    {       
        carFactory.activeCars.Remove(this.gameObject);
        carFactory.inActiveCars.Add(this.gameObject); 
    }

    public void OnDead()
    {
        GameObject.Destroy(car);
    }

    public void OnInitialized()
    {

    }
}
