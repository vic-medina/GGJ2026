using GGJ2026.Player.BaseMovement;
using System;
using UnityEngine;

public class EagleAbility : MonoBehaviour
{
    [Header("References")]
    public MovementController movController;
    public Rigidbody2D rb;
    public FloorsDetections floorsDetections;

    [Header("Settings")]
    public float dashDirection;
    public float dashForce;
    public float dashCooldown;
    public float dashTimer;
    public float movCooldown;
    public float movTimer;
    public bool canDash;
    public bool canLevitate;
    public Action OnDash;

    private void Start()
    {
        //floorsDetections.OnAir += () => { canLevitate = true; }; 
        floorsDetections.OnGround += () => { canLevitate = false; };
        canDash = true;
        OnDash = () =>
        {
            movTimer -= Time.deltaTime;
            if (movTimer <= 0)
            {
                movController.stopMovement = false;
                canLevitate = true;
            }
        };
    }

    private void OnEnable()
    {
        canLevitate = true;
    }

    private void Update()
    {
        dashDirection = movController.horizontalInput;
        if (!canDash)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0)
            {
                canDash = true;
            }
        }
        if (movController.stopMovement)
        {
            movTimer -= Time.deltaTime;
            if (movTimer <= 0f)
            {
                movController.stopMovement = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            if (movController.horizontalInput == 0) return;
            Dash(new Vector2(movController.horizontalInput, 0f));
        }


        if (Input.GetKeyUp(KeyCode.Space)) { canLevitate = true; }

        if (Input.GetKey(KeyCode.Space))
        {
            if (!canLevitate) { return; }
            rb.gravityScale = .3f;
            rb.linearVelocity = new Vector2(movController.horizontalInput, -1f);
        }
    }

    void Dash(Vector2 direction)
    {
        canDash = false;
        dashTimer = dashCooldown;

        movController.stopMovement = true;
        movTimer = movCooldown;

        rb.linearVelocity = Vector2.zero;
        rb.AddForce(direction.normalized * dashForce, ForceMode2D.Impulse);
    }
}
