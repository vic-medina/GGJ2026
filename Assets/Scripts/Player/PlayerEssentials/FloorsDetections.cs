using UnityEngine;


namespace GGJ2026.Player.BaseMovement
{
    public class FloorsDetections : MonoBehaviour
    {
        [Header("Ground")]
        public Transform groundCheck;
        public LayerMask groundLayer;
        public bool isGrounded;

        [Header("Water")]
        public LayerMask waterLayer;
        public bool isSubmerged;

        [Header("EdgeWater")]
        public Transform edgeCheck;
        public bool edgeUnderWater;

        [Header("RaycastSettings")]
        public float rayDistance;

        private void FixedUpdate()
        {
            CheckGround();
            CheckWater();
            CheckEdgeWater();
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