using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]  float _speed = 1;
    [SerializeField]  float _jumpForce = 200;
    [SerializeField] int _maxJumps;

    Vector3 _startPosition;
    int _jumpsRemaining;
    
    void Start()
    {
        _startPosition = transform.position;
        _jumpsRemaining = _maxJumps;
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal") * _speed;
        var rigidbody2D = GetComponent<Rigidbody2D>();

        if (Mathf.Abs(horizontal) >= 1)
        {
            rigidbody2D.velocity = new Vector2(horizontal, rigidbody2D.velocity.y);
            Debug.Log($"Velocity = {rigidbody2D.velocity}");
        }

        var animator = GetComponent<Animator>();
        bool walking = horizontal != 0;
        animator.SetBool("Walk", walking);

        if (horizontal != 0)
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = horizontal < 0;
        }

        if(Input.GetButtonDown("Fire1") && _jumpsRemaining > 0)
        {
            rigidbody2D.AddForce(Vector2.up * _jumpForce);
            _jumpsRemaining--;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        _jumpsRemaining = _maxJumps;
    }

    internal void ResetToStart()
    {
        transform.position = _startPosition;
    }
}
