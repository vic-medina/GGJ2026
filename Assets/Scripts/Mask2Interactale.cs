using UnityEngine;

public class Mask2Interactale : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public int maskIndex = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var assingMask = collision.GetComponent<MaskManager>();
        if (assingMask.currentMask != maskIndex)
        {
            return;
        }

        MoveObj(5f);
        Debug.Log("Si");
    }

    private void MoveObj(float distance)
    {
        rb2D.AddForceX(-distance, ForceMode2D.Impulse);
    }
}
