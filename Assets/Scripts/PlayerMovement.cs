using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 3f;
    public float jumpSpeed = 1f;
    public PlayerSounds playerSounds;

    private bool isGrounded = true;
    private bool isInsideLeverBounds = false;
    private Lever lever;
    private Rigidbody rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        int fakeVelocity = 0;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
            fakeVelocity += 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
            fakeVelocity -= 1;
        }

        // going right
        if (fakeVelocity > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 90, 0);
            if (isGrounded)
            {
                playerSounds.PlayAudioClip(playerSounds.walk, volume: 0.1f);
            }
        }
        // going left
        if (fakeVelocity < 0)
        {
            transform.localRotation = Quaternion.Euler(0, -90, 0);
            if (isGrounded)
            {
                playerSounds.PlayAudioClip(playerSounds.walk, volume: 0.1f);
            }
        }

        animator.SetInteger("fakeVelocity", fakeVelocity);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                animator.SetTrigger("Jump");
                rb.AddForce(Vector3.up * jumpSpeed);
                isGrounded = false;
                animator.SetBool("isGrounded", isGrounded);
                playerSounds.PlayAudioClip(playerSounds.jump, volume: 0.5f);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (rb.velocity.y <= 0)
        {
            isGrounded = true;
            animator.SetBool("isGrounded", isGrounded);


            if (Time.timeSinceLevelLoad > 1)
            {
                playerSounds.PlayAudioClip(playerSounds.hitGround, volume: 0.5f);
            }
        }
    }

    public void AnimateButtonPress()
    {
        animator.SetTrigger("interact");
        playerSounds.PlayAudioClip(playerSounds.pullLever, volume: 0.5f);
    }
}
