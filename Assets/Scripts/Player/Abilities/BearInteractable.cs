using GGJ2026.Player.BaseMovement;
using UnityEngine;

namespace GGJ2026.Ability.Bear
{
    public enum InteractableTypes
    {
        WALL,
        OBJ
    }
    public class BearInteractable : MonoBehaviour
    {
        public float direction;
        public float incomingForce;
        public bool isMoving;

        public InteractableTypes interactableTypes;

        void Start()
        {

        }

        private void FixedUpdate()
        {
            if (!isMoving) { return; }
            Move();
        }

        void Move()
        {
            var pos = transform.position;

            if (direction == -1)
            {
                pos.x -= incomingForce * Time.deltaTime;
            }
            else if (direction == 1)
            {
                pos.x += incomingForce * Time.deltaTime;
            }
            transform.position = pos;
        }

        public void StopMove()
        {
            isMoving = false;
        }
    }
}