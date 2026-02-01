using UnityEngine;

public class Door : MonoBehaviour
{
    public Vector2 locationToTp;
    public Transform subject;
    public bool canTp;

    private void Update()
    {
        if (!canTp) { return; }
        if (Input.GetKeyDown(KeyCode.E))
        {
            DoorTeleport(subject);
        }
    }

    void DoorTeleport(Transform subject)
    {
        subject.position = locationToTp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canTp = true;
        subject = collision.gameObject.transform;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTp = false;
    }
}
