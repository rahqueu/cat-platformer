using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;
    private Animator animator;
    
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("dead", false);
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);


        if (horizontalInput == 0)
        {
            animator.SetBool("walk", false);
        } else
        {
            animator.SetBool("walk", true);
        }

        if (verticalInput != 0)
        {
            animator.SetBool("jump", true);
        } else
        {
            animator.SetBool("jump", false);
        }

        // FLip the player
        if (horizontalInput > 0.01f)
        {
            animator.SetBool("walk", true);
            transform.localScale = Vector3.one;
        } else if (horizontalInput < -0.01f)
        {
            animator.SetBool("walk", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Jump
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("jump", true);
            body.velocity = new Vector2(body.velocity.x, speed);
        }

        if (Input.GetKey(KeyCode.LeftShift) && (horizontalInput != 0))
        {
            animator.SetBool("run", true);
            body.velocity = new Vector2(horizontalInput * speed * 2, body.velocity.y);
        } else
        {
            animator.SetBool("run", false);
        }

        

    }

}
