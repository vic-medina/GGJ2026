using UnityEngine;

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

                player.Die();
            }
        }
    }
}
