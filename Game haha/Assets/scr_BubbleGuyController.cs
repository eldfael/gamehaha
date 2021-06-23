using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_BubbleGuyController : MonoBehaviour, Enemy
{
    float hitTimerDuration;
    float hitTimer;
    Animator animator;
    Vector2 moveDirection;
    float moveSpeed;
    Rigidbody2D rigidbody2d;

    private void Start()
    {
        hitTimer = 0;
        hitTimerDuration = 0.3f;
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        moveSpeed = 0f;
        
    }
    public void TakeDamage(int damage, Vector2 direction)
    {
        moveDirection = direction;
        moveSpeed = 30f;
        hitTimer = hitTimerDuration;
        animator.Play("Bubble_Hit");

    }

    private void FixedUpdate()
    {
        if (hitTimer > 0)
        {
            hitTimer -= Time.fixedDeltaTime;
        }
        else if (hitTimer <= 0)
        {
            animator.Play("Bubble_Idle");
            moveDirection = Vector2.zero;
        }

            rigidbody2d.velocity = moveDirection * moveSpeed;
        
    }
}
