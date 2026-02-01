using GGJ2026.Player.BaseMovement;
using UnityEngine;


namespace GGJ2026.Ability.Frog
{
    public class FrogAbility : MonoBehaviour
    {
        [Header("References")]
        public MovementController movController;
        public FloorsDetections floorsDetections;
        public Rigidbody2D rb;

        [Header("Settings")]
        public float doubleJumpForce;
        public float swimSpeed;
        public bool canDoubleJump;
        public bool canSwim;

        private void Start()
        {
            floorsDetections.OnGround += EneableDoubleJump;
            floorsDetections.OnWater += EneableDoubleJump;
            floorsDetections.UnderWater += () => 
                {
                    canSwim = true;
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
                    rb.gravityScale = .75f;
                };
            floorsDetections.OnAir += () => 
                { 
                    canSwim = false; 
                    rb.gravityScale = 1f;
                };
        }
         
        void Update()
        {
            if (!canDoubleJump) { return; }
            if (Input.GetButtonDown("Jump") && floorsDetections.onAir)
            {
                DoubleJump();
            }

            //if (floorsDetections.isSubmerged && floorsDetections.edgeUnderWater)
            //{
            //    rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            //    rb.gravityScale = .75f;
            //}
        }

        void FixedUpdate()
        {
            if(!canSwim) { return; }
            rb.linearVelocity = new Vector2(movController.horizontalInput * swimSpeed, movController.verticalInput * swimSpeed);
        }

        void DoubleJump()
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * doubleJumpForce, ForceMode2D.Impulse);
            canDoubleJump = false;
        }

        void EneableDoubleJump()
        {
            canDoubleJump = true;
        }
    }
}