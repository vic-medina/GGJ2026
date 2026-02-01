using System;
using UnityEngine;

public class MovibleObj : MonoBehaviour
{
    public Vector2 pointToReach;
    public Vector2 initialPos;
    public float speed = 2f;
    public bool loop;
    public Action OnPointReached;

    private void Awake()
    {
        initialPos = transform.position;
    }

    private void FixedUpdate()
    {

        Move(pointToReach);

        if (Vector2.Distance(transform.position, pointToReach) < 0.01f)
        {
            OnPointReached?.Invoke();

            if (loop)
            {
                var temp = pointToReach;
                pointToReach = initialPos;
                initialPos = temp;
            }
        }
    }

    void Move(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            target,
            speed * Time.fixedDeltaTime
        );
    }
}