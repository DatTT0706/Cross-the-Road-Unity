using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Vector3 Vec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vec = transform.position;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vec.y += 5;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vec.x -= 5;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vec.x += 5;
        }
        //Vec.x += Input.GetKeyDown("Horizontal") * Time.deltaTime * 60;
        
        transform.position = Vector3.MoveTowards(transform.position ,Vec, 1);
    }
}
