using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateListener : StateChangeListener
{
    private GameObject playerPrefs;

    public PlayerStateListener(GameObject playerPrefs)
    {
        this.playerPrefs = playerPrefs;
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

    public void OnActive()
    {
        playerPrefs.SetActive(true);
    }

    public void OnDeactive()
    {
        playerPrefs.SetActive(false);
    }

    public void OnDead()
    {
        GameObject.Destroy(playerPrefs);
    }
    
    public void OnInitialized()
    {
        playerPrefs.SetActive(false);
    }
}
