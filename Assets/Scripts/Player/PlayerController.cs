using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private Animator animator;
    private bool isGrounded;

    void Start()
    {
        // Get the Animator component attached to the player
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
        transform.Translate(movement);
        

        // Player animations
        if (movement.magnitude > 0)
        {
            // Player is moving, play walk or run animation based on input
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                // Run
                animator.SetBool("Run", true);
                animator.SetBool("Walk", false);
            }
            else
            {
                // Walk
                animator.SetBool("Walk", true);
                animator.SetBool("Run", false);
            }
        }
        else
        {
            // Player is not moving
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
        }
    
        // // Player hitting
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     // Trigger the hit animation
        //     animator.SetTrigger("hit");
        // }
    
        // Player jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Apply a force to make the player jump
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            animator.SetBool("Jump", true);
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        // Check if the player is grounded when colliding with the ground
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("Jump", false);
        }
    }
}

