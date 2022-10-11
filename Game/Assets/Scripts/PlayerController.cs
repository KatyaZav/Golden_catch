using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float speed;

    [SerializeField] GameObject changeMoveEffect;
    moveDirection _moveDirection;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");

        var movement = new Vector2(x, 0);
        _rb.AddForce(movement * speed);

        CheckChangeDirection(x);
               
    }

    private void CheckChangeDirection(float x)
    {
        if (Math.Round(x) != (int)_moveDirection)
        {
            _moveDirection = (moveDirection)Math.Round(x);

            Debug.Log("changed");
            
            //var ef = Instantiate(changeMoveEffect);
            //ef.transform.position = transform.position;
        }
    }

    enum moveDirection
    {
        right = 1,
        left = -1
    };
}

