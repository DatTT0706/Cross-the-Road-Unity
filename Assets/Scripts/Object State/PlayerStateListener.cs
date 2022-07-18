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

    public void OnActive()
    {
        throw new System.NotImplementedException();
    }

    public void OnCharacterStateChanged(ObjectState state)
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
