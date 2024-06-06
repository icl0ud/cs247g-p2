using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;

    private float runMaxSpeed = 8f;
    private float runAccelAmount = 8f;
    private float runDeccelAmount = 16f;
    private float accelInAir = 0.5f;
    private float deccelInAir = 0.5f;
    private bool doConserveMomentum = true;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    private float jumpingForce = 16f;

    private bool isFacingRight = true;
    private bool isJumping;
    private float lastOnGroundTime = 0.1f;
    private float coyoteTime = 0.2f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip walkClip;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        lastOnGroundTime -= Time.deltaTime;
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (IsGrounded()) {
            Debug.Log("Grounded!");
            lastOnGroundTime = coyoteTime;
        }

        Jump();    
        Flip();
    }

    private void FixedUpdate()
    {
        Run();
    }

    private void Run()
    {
        float targetSpeed = horizontal * runMaxSpeed;
        float accelRate;

        if (lastOnGroundTime > 0)
            accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? runAccelAmount : runDeccelAmount;
        else
            accelRate = (Mathf.Abs(targetSpeed) > 0.0f) ? runAccelAmount * accelInAir : runAccelAmount * deccelInAir;
        
        if (doConserveMomentum && Mathf.Abs(rb.velocity.x) > Mathf.Abs(targetSpeed) && Mathf.Sign(rb.velocity.x) ==
                Mathf.Sign(targetSpeed) && Mathf.Abs(targetSpeed) > 0.01f && lastOnGroundTime < 0)
            accelRate = 0;
        
        float speedDiff = targetSpeed - rb.velocity.x;
        float movement = speedDiff * accelRate;

        rb.AddForce(movement * Vector2.right, ForceMode2D.Force);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (lastOnGroundTime > 0f && jumpBufferCounter > 0f && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingForce);
            SoundFXManager.instance.PlaySoundFXClip(jumpClip, transform, 1f);
            jumpBufferCounter = 0f;
            StartCoroutine(JumpCooldown());
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            lastOnGroundTime = 0f;
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.4f);
        isJumping = false;
    }
}