using UnityEngine;
using GGJ2026.Player.Health;

namespace GGJ2026.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        public bool isAttacking;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (isAttacking)
            {
                var player = collision.GetComponent<PlayerHealth>();
                if (player != null)
                {
                    player.TakeDamage();
                }
            }
        }
    }
}
