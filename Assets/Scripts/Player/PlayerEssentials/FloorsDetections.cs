using System;
using UnityEngine;


namespace GGJ2026.Player.BaseMovement
{
    public class FloorsDetections : MonoBehaviour
    {
        [Header("Ground")]
        public Transform groundCheck;
        public LayerMask groundLayer;
        public bool isGrounded;
        public Action OnGround;

        [Header("OnAir")]
        public bool onAir;
        public Action OnAir;

        [Header("Water")]
        public LayerMask waterLayer;
        public bool isSubmerged;
        public Action OnWater;

        [Header("EdgeWater")]
        public Transform edgeCheck;
        public bool edgeUnderWater;
        public Action UnderWater;

        [Header("RaycastSettings")]
        public float rayDistance;

        private void Update()
        {
            CheckGround();
            CheckWater();
            CheckEdgeWater();

            if (!isSubmerged)
            {
                if (!isGrounded && !edgeUnderWater)
                {
                    onAir = true;
                    OnAir?.Invoke();
                    return;
                }
                onAir = false;
            }
        }

        void CheckGround()
        {
            RaycastHit2D hit = Physics2D.Raycast(
                groundCheck.position,
                Vector2.down,
                rayDistance,
                groundLayer
            );

            isGrounded = hit.collider != null;
            if (isGrounded)
            {
                OnGround?.Invoke();
                onAir = false;
            }
        }

        void CheckWater()
        {
            RaycastHit2D hit = Physics2D.Raycast(
                groundCheck.position,
                Vector2.down,
                rayDistance,
                waterLayer
            );

            isSubmerged = hit.collider != null;
            if (isSubmerged)
            {
                OnWater?.Invoke();
            }
        }

        void CheckEdgeWater()
        {
            RaycastHit2D hit = Physics2D.Raycast(
                edgeCheck.position,
                Vector2.right,
                rayDistance,
                waterLayer
            );

            edgeUnderWater = hit.collider != null;
            if (edgeUnderWater)
            {
                UnderWater?.Invoke();
                onAir = false;
            }
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(
                groundCheck.position,
                groundCheck.position + Vector3.down * rayDistance
            );

            Gizmos.color = Color.red;
            Gizmos.DrawLine(
                edgeCheck.position,
                edgeCheck.position + Vector3.right * rayDistance
            );
        }
    }
}