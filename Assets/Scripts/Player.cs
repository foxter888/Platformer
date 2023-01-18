using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 1;
    [SerializeField] private float jumpForce = 200;


    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal") * speed;
        var rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(horizontal, rigidbody2D.velocity.y);
        Debug.Log($"Velocity = {rigidbody2D.velocity}");

        var animator = GetComponent<Animator>();
        bool walking = horizontal != 0;
        animator.SetBool("Walk", walking);

        if (horizontal != 0)
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = horizontal < 0;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce);
        }
    }
}
