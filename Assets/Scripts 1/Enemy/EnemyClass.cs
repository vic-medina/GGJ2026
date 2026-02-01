using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    public float speed = 2f;       // velocidad de movimiento
    public float moveDuration = 2f; // tiempo que avanza
    public float waitDuration = 1f; // tiempo que espera
    public float limitDir = 1f;    // rango de dirección aleatoria

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

    void Awake()
    {
        currentDir = GetRandomDir();
        timer = moveDuration;
        isWaiting = false;
    }

    void FixedUpdate()
    {
        CheckGround();
        //if (chasingPlayer && !canWalk)
        //{
        //    var pos = transform.position;
        //    pos.x += -1 * speed * Time.fixedDeltaTime;
        //    transform.position = pos;
        //    return;
        //}
        if (chasingPlayer)
        {
            Debug.LogWarning("Cazando");
            var playerDistance = (playerTf.position.x - transform.position.x);
            var pos = transform.position;
            pos.x += playerDistance * chaseSpeed * Time.deltaTime;
            transform.position = pos;
            return;
        }
        if (!canWalk && !chasingPlayer)
        {
            currentDir *= -1;
            var pos = transform.position;
            pos.x += currentDir * speed * Time.fixedDeltaTime;
            transform.position = pos;
        }
        if (canWalk && !chasingPlayer)
        {
            if (!isWaiting)
            {
                // mover al enemigo
                //transform.position += new Vector3(currentDir, 0f, 0f) * speed * Time.fixedDeltaTime;
                var pos = transform.position;
                pos.x += currentDir * speed * Time.fixedDeltaTime;
                transform.position = pos;

                timer -= Time.fixedDeltaTime;
                if (timer <= 0f)
                {
                    // pasa a estado de espera
                    isWaiting = true;
                    timer = waitDuration;
                }
            }
            else
            {
                // enemigo quieto
                timer -= Time.fixedDeltaTime;
                if (timer <= 0f)
                {
                    // cambia dirección y vuelve a moverse
                    currentDir = GetRandomDir();
                    isWaiting = false;
                    timer = moveDuration;
                }
            }
        }
    }

    private float GetRandomDir()
    {
        float newDir = Random.Range(-limitDir, limitDir);
        if (newDir == 0f)
        {
            newDir = 1f; // evitar quedarse en 0
        }
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

        if (isGrounded)
        {
            canWalk = true;
        }
        else
        {
            canWalk = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(
            groundCheck.position,
            groundCheck.position + Vector3.down * groundCheckDistance
        );
    }
}