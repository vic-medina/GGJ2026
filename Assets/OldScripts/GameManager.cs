using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerMovement player;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            player.Restart();
        }
    }
}
