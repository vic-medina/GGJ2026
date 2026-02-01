using UnityEngine;
using GGJ2026.Player;

namespace GGJ2026.Player.BaseMovement
{
    public class MovementController : MonoBehaviour
    {
        [Header("References")]
        public Rigidbody2D rb;
        public FloorsDetections floorDetect;
        public EagleAbility eagleAbility;
        public Animator anim;

        [Header("BaseMovement")]
        public float moveSpeed;
        public float jumpForce;
        public bool stopMovement;

        [Header("Position")]
        public float horizontalInput;
        public float verticalInput;
        public Vector2 initialPos;

        void Start()
        {
            floorDetect.OnGround += () =>
            {

            };
        }

        public void Restart()
        {
            transform.position = initialPos;
        }

        private void Awake()
        {
            initialPos = transform.position;
        }

        void Update()
        {
            if (stopMovement) { return; }
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
            //anim.SetBool("Idle", floorDetect.isGrounded);

            if (floorDetect.isGrounded)
            {
                Debug.Log("Suelo");
                bool isRunning = horizontalInput != 0 && !stopMovement;
                Debug.Log(isRunning);
                anim.SetBool("Run", isRunning);
                anim.SetBool("Idle", !isRunning);
            }
            else
            {
                // En el aire: desactivar Idle y Run
                anim.SetBool("Run", false);
                anim.SetBool("Idle", false);
            }

            // Flip según dirección
            if (horizontalInput > 0)
            {
                transform.localScale = new Vector3(1, 1, 1); // derecha
            }
            else if (horizontalInput < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1); // izquierda
            }

            if (Input.GetButtonDown("Jump") && floorDetect.isGrounded)
            {
                Jump();
            }
        }

        private void FixedUpdate()
        {
            if (stopMovement) { return; }
            rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
        }

        void Jump()
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetTrigger("Jump");
        }
    }
}