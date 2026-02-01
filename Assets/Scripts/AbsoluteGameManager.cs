using UnityEngine;
using GGJ2026.Player.BaseMovement;
using GGJ2026.Player.Health;

public class AbsoluteGameManager : MonoBehaviour
{
    public MovementController movController;
    public PlayerHealth playerHealth;


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            movController.Restart();
            playerHealth.Restart();
        }
    }
}
