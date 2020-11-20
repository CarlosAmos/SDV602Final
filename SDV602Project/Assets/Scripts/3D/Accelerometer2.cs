using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used for the accelerometer in the minigame
public class Accelerometer2 : MonoBehaviour
{
    private Rigidbody rigid;
    private float dirX;
    private float moveSpeed = 200f;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    //Used for getting direction of phone and times the direction by the set speed
    void Update()
    {
        dirX = Input.acceleration.x * moveSpeed;
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    //used for moving the sphere if the phone direction but only on X axis.
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(dirX, 0f);
    }
    
}
