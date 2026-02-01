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
            //eagleAbility.OnDash += () =>
            //{
            //    stopMovement = true;
            //};
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
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

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
        }
    }
}