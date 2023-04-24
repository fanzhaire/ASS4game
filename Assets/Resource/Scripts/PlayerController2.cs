using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float checkRadius = 0.5f;

    private Rigidbody2D rb;
    private bool isGrounded;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;
    public bool Switched = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObject();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ToggleSwitch();
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Set the isMoving parameter based on player input
        animator.SetBool("isMoving", Mathf.Abs(moveInput) > 0);
        // Set the isGrounded parameter
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("switched", Switched);
        // Flip the sprite based on the movement direction
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void InteractWithObject()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, 2f);

        if (hit.collider != null && hit.collider.CompareTag("Interactable"))
        {
            Debug.Log("Interacting with " + hit.collider.name);
            // Implement any additional interaction logic here
        }
    }

    private void ToggleSwitch()
    {
        if (Switched)
        {


            Switched = false;
        }
        else
        {

            Switched = true;
        }
    }
}

