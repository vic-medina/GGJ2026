using UnityEngine;
using GGJ2026.Player.Health;

public class EnemyAttack : MonoBehaviour
{
    public bool isAttacking;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entro a Attack");
        if (isAttacking)
        {
            var player = collision.GetComponentInChildren<PlayerHealth>();
            if (player != null)
            {
                Debug.Log("Player");
                player.TakeDamage();
            }
        }
    }
}
