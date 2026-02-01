using UnityEngine;

public class Mask3Behavior : MonoBehaviour 
{
    public PlayerMovement playerMov;

    private void OnEnable()
    {
        playerMov.enableDash = true;
        //playerMov.enableSwim = true;
    }

    private void OnDisable()
    {
        playerMov.enableDash = false;
        //playerMov.enableDoubleJump = false;
    }
}
