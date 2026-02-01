using UnityEngine;
using GGJ2026.Player.BaseMovement;
using GGJ2026.Player.Health;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using System.Collections.Generic;

public class AbsoluteGameManager : MonoBehaviour
{
    public MovementController movController;
    public PlayerHealth playerHealth;
    public GameObject gameOverScreen;
    public List<EnemyClass> enemyClasses = new List<EnemyClass>();

    private void Awake()
    {
        gameOverScreen.SetActive(false);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        movController.Restart();
        playerHealth.Restart();
        gameOverScreen.SetActive(false);

        foreach(var enemy in enemyClasses)
        {
            enemy.Restart();
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            Restart();
        }
    }
}
