using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("BaseMovement")]
    public float moveSpeed = 8f;
    public float jumpForce = 12f;

    [Header("DoubleJump")]
    public bool enableDoubleJump;
    private bool canDoubleJump;

    [Header("CanSwim")]
    public bool enableSwim;
    public bool canDive;
    public float swimSpeed;

    [Header("PushObjs")]
    public bool enablePushObjs;
    public float playerStrenght;

    [Header("CanClimb")]
    public bool enableClimb;
    public bool onClimbableSurface;
    public float climbSpeed;

    [Header("GroundDetection")]
    public Transform groundCheck;
    public Transform waterCheck;
    public float groundCheckDistance = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    [Header("WaterDetection")]
    public LayerMask waterLayer;
    private bool isInTheWater;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    public float horizontalInput;
    private float verticalInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                Jump();
                canDoubleJump = true;
            }
            else if (enableDoubleJump && canDoubleJump)
            {
                Jump();
                canDoubleJump = false;
            }
        }

        if(enableClimb && onClimbableSurface && Input.GetKey(KeyCode.W))
        {
            Climb();
        }
    }

    void Climb()
    {
        if (!onClimbableSurface) { return; }
        rb.linearVelocity = new Vector2 (horizontalInput * climbSpeed, verticalInput * climbSpeed);
    }


    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
        CheckGround();
        CheckWater();
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            groundCheck.position,
            Vector2.down,
            groundCheckDistance,
            groundLayer
        );

        isGrounded = hit.collider != null;

        if (isGrounded)
            canDoubleJump = true;
    }
    void CheckWater()
    {
        RaycastHit2D edgeWaterHit = Physics2D.Raycast(
            waterCheck.position,
            Vector2.right,
            groundCheckDistance,
            waterLayer
        );
        bool isInTheEdge = edgeWaterHit.collider != null;

        if (isInTheEdge)
        {
            RaycastHit2D hit = Physics2D.Raycast(
                groundCheck.position,
                Vector2.down,
                groundCheckDistance,
                waterLayer
            );


            isInTheWater = hit.collider != null;



            if (enableSwim && isInTheWater && isInTheEdge)
            {
                rb.gravityScale = .75f;
                rb.linearVelocity = new Vector2(horizontalInput * swimSpeed, verticalInput * swimSpeed);
            }
            else if (enableSwim && isInTheWater && !isInTheEdge)
            {
                rb.gravityScale = .75f;
                rb.linearVelocity = new Vector2(horizontalInput * swimSpeed, verticalInput * swimSpeed);
            }
            else if (!enableSwim && isInTheWater)
            {
                // Gravedad normal fuera del agua
                rb.gravityScale = -.5f;
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 1f);
                if (!isInTheEdge)
                {
                    rb.gravityScale = 0f;
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
                }
            }
            else
            {
                rb.gravityScale = 1f;
            }
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(
            groundCheck.position,
            groundCheck.position + Vector3.down * groundCheckDistance
        );

        Gizmos.color = Color.red;
        Gizmos.DrawLine(
            waterCheck.position,
            waterCheck.position + Vector3.right * groundCheckDistance
        );
    }
}
