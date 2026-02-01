using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public int gameSceneIndex;
    public GameObject creditsPanel;

    private void Awake()
    {
        creditsPanel.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneIndex);
    }

    public void GoToCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void GoToMainMenu()
    {
        creditsPanel.SetActive(false);
    }
}
