using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 13f;
    [SerializeField] private int facingDirection = 1;

    [Header("Ground Check Settings")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isGrounded;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private CapsuleCollider2D capsuleCollider;

    [Header("Duck Settings")]
    [SerializeField] private Vector2 duckColliderOffset;
    [SerializeField] private Vector2 standingColliderOffset;
    [SerializeField] private bool isDucking;

    [Header("Input")]
    [SerializeField] private float moveInput;

    void Update()
    {
        if(isDucking)
        {
            return;
        }
        moveInput = Input.GetAxisRaw("Horizontal");

        Jump();

        if(moveInput > 0 && transform.localScale.x < 0 || moveInput < 0 && transform.localScale.x > 0)
        {
            Flip();
        }

        HandleAnimations();
    }

    void FixedUpdate()
    {
        Duck();

        DuckUp();

        Move();
    }

    void Move()
    {
         rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void Duck()
    {
        if(Input.GetKey(KeyCode.L))
        {
            isDucking = true;
            capsuleCollider.size = duckColliderOffset;
            animator.SetBool("isDucking", true);
        }
    }

    void DuckUp()
    {
        if(Input.GetKeyUp(KeyCode.L))
        {
            isDucking = false;
            capsuleCollider.size = standingColliderOffset;
            animator.SetBool("isDucking", false);
        }
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    void HandleAnimations()
    {
        if(isDucking)
        {
            return;
        }
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        animator.SetBool("isJumping", rb.linearVelocity.y > 0.1f);
    }
}