using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ObjectState
{
    INITIALIZED,
    ACTIVE,
    DEACTIVE,
    DEAD
}

interface StateChangeListener
{
    void OnCharacterStateChanged(ObjectState state);
    void OnInitialized();
    void OnActive();
    void OnDeactive();
    void OnDead();
}