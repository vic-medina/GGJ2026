using GGJ2026.Mask;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public Vector2 locationToTp;
    public Transform subject;
    public bool canTp;
    public Animator anim;
    public int correctMask;
    public int currentMask;

    private bool isOpen; // nuevo flag para saber si la puerta está abierta

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
        var mask = collision.GetComponentInChildren<MaskManager>();
        if (mask == null) { return; }
        subject = collision.gameObject.transform;
        currentMask = mask.currentMask;

        if (currentMask == correctMask && !isOpen)
        {
            canTp = true;
            isOpen = true;
            anim.SetTrigger("Open");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var mask = collision.GetComponentInChildren<MaskManager>();
        if (mask == null) { return; }
        currentMask = mask.currentMask;

        if (currentMask != correctMask && isOpen)
        {
            canTp = false;
            isOpen = false;
            anim.SetTrigger("Close");
        }
        else if (currentMask == correctMask && !isOpen)
        {
            canTp = true;
            isOpen = true;
            anim.SetTrigger("Open");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isOpen)
        {
            canTp = false;
            isOpen = false;
            anim.SetTrigger("Close");
        }
    }
}