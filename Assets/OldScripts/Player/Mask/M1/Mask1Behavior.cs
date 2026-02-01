using UnityEngine;

public class Mask1Behavior : MonoBehaviour 
{
    public PlayerMovement playerMov;

    private void OnEnable()
    {
        playerMov.enableDoubleJump = true;
        playerMov.enableSwim = true;
    }

    private void OnDisable()
    {
        playerMov.enableSwim = false;
        playerMov.enableDoubleJump = false;
    }
}
