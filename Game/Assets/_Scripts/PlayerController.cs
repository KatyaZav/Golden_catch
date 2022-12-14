using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    delegate void MakeMove();
    MakeMove movingState;

    [SerializeField] bool useAuto;

    Rigidbody2D _rb;
    [SerializeField] float speed;

    [SerializeField] GameObject changeMoveEffect;
    moveDirection _moveDirection;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        if (useAuto) 
            movingState = AutoMove;
        else
            movingState = Move;

        _moveDirection = moveDirection.right;
    }

    void FixedUpdate()
    {
        movingState();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");

        var movement = new Vector2(x, 0);
        _rb.AddForce(movement * speed);

        CheckChangeDirection(x);
               
    }

    private void AutoMove()
    {
        if (UnityEngine.Random.Range(0, 10) > 7)
            if (_moveDirection == moveDirection.left)
                _moveDirection = moveDirection.right;
            else
                _moveDirection = moveDirection.left;
                
        var movement = new Vector2(UnityEngine.Random.Range(0f, 3f) * (int)_moveDirection, 0);
        _rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Border")
        {
            ICollectable collect = collision.gameObject.GetComponent<ICollectable>();

            if (collect != null)
            {
                collect.Collect();
            }
            else
            {
                Debug.LogWarning("Catched strange object: " + collision.ToString());
                Destroy(collision.gameObject);
            }
        }
    }

    private void CheckChangeDirection(float x)
    {
        if (Math.Round(x) != (int)_moveDirection)
        {
            _moveDirection = (moveDirection)Math.Round(x);
        }
    }

    enum moveDirection
    {
        right = 1,
        left = -1
    };
}

