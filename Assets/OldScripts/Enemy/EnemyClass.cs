using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    public float speed = 2f;
    public float moveDuration = 2f;
    public float waitDuration = 1f;
    public float limitDir = 1f;

    public Transform groundCheck;
    public float groundCheckDistance = 0.2f;
    private bool isGrounded;
    public LayerMask groundLayer;

    public bool canWalk = false;

    public bool chasingPlayer;
    public Transform playerTf;
    public float chaseSpeed;

    [SerializeField] private float timer;
    [SerializeField] private float currentDir;
    [SerializeField] private bool isWaiting;

    // Animator
    public Animator anim;
    private string currentAnimState;

    // SpriteRenderer para flip
    public SpriteRenderer spriteRenderer;

    void Awake()
    {
        currentDir = GetRandomDir();
        timer = moveDuration;
        isWaiting = false;
    }

    void FixedUpdate()
    {
        CheckGround();

        if (chasingPlayer)
        {
            var playerDistance = (playerTf.position.x - transform.position.x);
            var pos = transform.position;
            pos.x += playerDistance * chaseSpeed * Time.deltaTime;
            transform.position = pos;

            SetAnimation("Run");

            // Flip hacia el jugador
            spriteRenderer.flipX = playerDistance < 0;
            return;
        }

        if (!canWalk && !chasingPlayer)
        {
            currentDir *= -1;
            var pos = transform.position;
            pos.x += currentDir * speed * Time.fixedDeltaTime;
            transform.position = pos;

            SetAnimation("Run");
        }

        if (canWalk && !chasingPlayer)
        {
            if (!isWaiting)
            {
                var pos = transform.position;
                pos.x += currentDir * speed * Time.fixedDeltaTime;
                transform.position = pos;

                timer -= Time.fixedDeltaTime;
                if (timer <= 0f)
                {
                    isWaiting = true;
                    timer = waitDuration;
                }

                SetAnimation("Run");
            }
            else
            {
                timer -= Time.fixedDeltaTime;
                if (timer <= 0f)
                {
                    currentDir = GetRandomDir();
                    isWaiting = false;
                    timer = moveDuration;
                }

                SetAnimation("Idle");
            }
        }

        // Flip según dirección en patrulla
        if (!chasingPlayer)
            spriteRenderer.flipX = currentDir < 0;
    }

    private float GetRandomDir()
    {
        float newDir = Random.Range(-limitDir, limitDir);
        if (newDir == 0f) newDir = 1f;
        return newDir;
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
        canWalk = isGrounded;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(
            groundCheck.position,
            groundCheck.position + Vector3.down * groundCheckDistance
        );
    }

    void SetAnimation(string newState)
    {
        if (currentAnimState == newState) return;
        currentAnimState = newState;
        anim.SetTrigger(newState);
    }
}