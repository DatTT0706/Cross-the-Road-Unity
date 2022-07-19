using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour
{
    private GameObject reference;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    public void onCharacterStateChanged(ObjectState state) 
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
                GameObject.Destroy(reference);
                break;
            default:
                break;
        }
    }
}

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