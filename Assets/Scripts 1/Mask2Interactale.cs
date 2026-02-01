using UnityEngine;

public enum Mask2Types
{
    WALL,
    OBJ
}

public class Mask2Interactale : MonoBehaviour
{
    public Mask2Types maskType;

    private PlayerMovement playerOnSurface;
    private MaskManager correctMask;
    private bool playerInside = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerOnSurface = collision.GetComponent<PlayerMovement>();
        correctMask = collision.GetComponent<MaskManager>();

        if (maskType == Mask2Types.OBJ && playerOnSurface != null && correctMask != null)
        {
            playerInside = true; // jugador dentro del trigger
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var exitingPlayer = collision.GetComponent<PlayerMovement>();
        if (maskType == Mask2Types.WALL && exitingPlayer != null)
        {
            exitingPlayer.onClimbableSurface = false;
        }

        if (maskType == Mask2Types.OBJ && exitingPlayer != null)
        {
            playerInside = false; // ya no está empujando
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (maskType == Mask2Types.WALL)
        {
            var player = collision.GetComponent<PlayerMovement>();
            var mask = collision.GetComponent<MaskManager>();

            if (player != null && mask != null)
            {
                //Aquí se recalcula en cada frame mientras el jugador está tocando la pared
                player.onClimbableSurface = (mask.currentMask == 1);
            }
        }
    }

    private void Update()
    {
        if (maskType == Mask2Types.OBJ && playerInside && playerOnSurface != null && correctMask != null)
        {
            if (correctMask.currentMask == 1) // solo si la máscara sigue siendo la correcta
            {
                var pos = transform.position;

                if (playerOnSurface.horizontalInput == -1)
                {
                    pos.x -= playerOnSurface.playerStrenght * Time.deltaTime;
                }
                else if (playerOnSurface.horizontalInput == 1)
                {
                    pos.x += playerOnSurface.playerStrenght * Time.deltaTime;
                }

                transform.position = pos;
            }
        }
    }
}