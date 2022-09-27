using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Horizontal Movement")]
    public float speed;
    public Vector2 dir;
    private bool facingRight = true;

    [Header("Vertical Movement")]
    public bool isJumping;
    public float jumpForce;

    [Header("Components")]
    public Rigidbody2D rb2d;
    public Animator animator;

    [Header("Physics")]
    public float maxSpeed;

    [Header("Input")]
    public PlayerControls input = null;
    public bool canMove = true;

    [Header("Collision")]
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;
    public BoxCollider2D stomper;

    void Awake()
    {
        input = new PlayerControls();

        input.Player.Jumping.performed += ctx => JumpingInput(ctx);
    }

    void OnEnable()
    {
        input.Player.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        if (isGrounded)
        {
            stomper.gameObject.SetActive(false);
        } else
        {
            stomper.gameObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {

        dir.x = input.Player.Movement.ReadValue<Vector2>().x;

        if (canMove) {
            MovePlayer(dir.x);
        }
        animator.SetBool("isGrounded", isGrounded);
    }

    void MovePlayer(float horizontal)
    {
        if (canMove) {
            rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);

            animator.SetFloat("Horizontal", Mathf.Abs(rb2d.velocity.x));

            if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
            {
                Flip();
            }

            if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            {
                rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
            }
        }
    }

    void Jump()
    {
        if (canMove) 
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
    }

    public void JumpingInput(InputAction.CallbackContext ctx)
    {
        if (canMove) {
            if (ctx.performed && isGrounded)
            {
                Jump();
                isJumping = true;
            } else {
                isJumping = false;
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
