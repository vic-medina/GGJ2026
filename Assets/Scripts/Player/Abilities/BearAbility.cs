using GGJ2026.Player.BaseMovement;
using GGJ2026.Ability.Bear;
using UnityEngine;
using System;

public class BearAbility : MonoBehaviour
{
    [Header("References")]
    public MovementController movController;
    public Rigidbody2D rb;

    [Header("Settings")]
    public float climbSpeed;
    public float strength;
    public bool canClimb;

    private void Update()
    {
        if (!canClimb) { movController.anim.SetTrigger("!Climb"); return; }
        if (Input.GetKey(KeyCode.W))
        {
            rb.linearVelocity = new Vector2(movController.horizontalInput * climbSpeed, movController.verticalInput * climbSpeed);
            movController.anim.SetTrigger("Climb");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var objInteraction = collision.GetComponent<BearInteractable>();
        if (objInteraction == null) { return; }

        switch (objInteraction.interactableTypes)
        {
            case InteractableTypes.WALL:
                canClimb = true;
                break;
            case InteractableTypes.OBJ:
                movController.anim.SetTrigger("Push");
                objInteraction.isMoving = true;
                objInteraction.direction = movController.horizontalInput;
                objInteraction.incomingForce = strength;
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var objInteraction = collision.GetComponent<BearInteractable>();
        if (objInteraction == null) { return; }

        switch (objInteraction.interactableTypes)
        {
            case InteractableTypes.WALL:
                canClimb = false;
                break;
            case InteractableTypes.OBJ:
                movController.anim.SetTrigger("!Push");
                objInteraction.StopMove();
                break;
            default:
                break;
        }
    }
}
