using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Vector3 Vec;
    private StateChangeListener mListener;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.isPlaying)
        {
            GetPlayerInput();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag=="Car")
        {
            GameController.instance.GameOver();
        }
    }

    public void GetPlayerInput()
    {
        Vec = transform.position;
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            Vec.y += 5;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Vec.x -= 5;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Vec.x += 5;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            Vec.y -= 5;
        }
        //Vec.x += Input.GetKeyDown("Horizontal") * Time.deltaTime * 60;

        transform.position = Vector3.MoveTowards(transform.position, Vec, 1);
    }
}
