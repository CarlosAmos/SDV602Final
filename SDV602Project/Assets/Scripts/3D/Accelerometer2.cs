using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer2 : MonoBehaviour
{
    private Rigidbody rigid;
    private float dirX;
    private float moveSpeed = 200f;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        dirX = Input.acceleration.x * moveSpeed;
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(dirX, 0f);
    }
    
}
