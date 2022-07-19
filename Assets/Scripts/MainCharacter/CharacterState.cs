using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour
{
    private ObjectState _state;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        _state = ObjectState.ALIVE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
}

enum ObjectState
{
    ALIVE,
    DEAD
}