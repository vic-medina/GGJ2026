using GGJ2026.Player.BaseMovement;
using UnityEngine;

namespace GGJ2026.Player.Health
{
    public class PlayerHealth : MonoBehaviour
    {
        public MovementController movementController;
        public int maxHealth;
        public int currentHealth;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        public void Restart()
        {
            movementController.stopMovement = false;
            currentHealth = maxHealth;
        }

        public void TakeDamage()
        {
            currentHealth -= 1;
            if(currentHealth <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            Debug.Log("Y murio");
            movementController.stopMovement = true;
        }
    }
}