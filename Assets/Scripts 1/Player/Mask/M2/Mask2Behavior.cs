using UnityEngine;

public class Mask2Behavior : MonoBehaviour
{
    public PlayerMovement playerMov;

    private void OnEnable()
    {
        playerMov.enablePushObjs = true;
        playerMov.enableClimb = true;
    }

    private void OnDisable()
    {
        playerMov.enablePushObjs = false;
        playerMov.enableClimb = false;
    }
}
