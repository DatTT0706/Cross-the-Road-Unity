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
                OnInitialized();
                break;
            case ObjectState.ACTIVE:
                OnActive();
                break;
            case ObjectState.DEACTIVE:
                OnDeactive();
                break;
            case ObjectState.DEAD:
                OnDead();
                break;
            default:
                break;
        }
    }

    public void OnDeactive()
    {       
        carFactory.activeCars.Remove(this.gameObject);
        carFactory.inactiveCars.Add(this.gameObject); 
    }

    public void OnDead()
    {
        GameObject.Destroy(car);
    }

    public void OnInitialized()
    {

    }
}
