using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStateListener : StateChangeListener
{
    public GameObject car;
    public CarStateListener(GameObject gameObject)
    {
        this.car = gameObject;
    }
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
        car.SetActive(false);
    }

    public void OnDead()
    {
        GameObject.Destroy(car);
    }

    public void OnInitialized()
    {
        
    }
}
