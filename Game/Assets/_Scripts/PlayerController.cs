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
        int x = UnityEngine.Random.Range(0, 10);
        if (x > 7)
            if (_moveDirection == moveDirection.left)
                _moveDirection = moveDirection.right;
            else
                _moveDirection = moveDirection.left;

        float movem = UnityEngine.Random.Range(0f, 3f);
        
        var movement = new Vector2(movem*(int)_moveDirection, 0);
        _rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
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

    private void CheckChangeDirection(float x)
    {
        if (Math.Round(x) != (int)_moveDirection)
        {
            _moveDirection = (moveDirection)Math.Round(x);

            //Debug.Log("changed");
            
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

