using UnityEngine;

namespace GGJ2026.Mask
{
    public class MaskPowerUps : MonoBehaviour
    {
        [Header("References")]
        public MaskManager maskManager;

        [Header("Setting")]
        public int currentPowerUps;

        [Header("FrogPowerUps")]
        public bool enableFrogPowerUps;
        public bool canDoubleJump;
        public bool canSwim;

        [Header("BearPowerUps")]
        public bool enableBearPowerUps;
        public bool canPushObjects;
        public bool canClimb;

        [Header("EaglePowerUps")]
        public bool enableEaglePowerUps;
        public bool canLevitate;
        public bool canDash;

        private void Start()
        {
            Restart();
        }

        void Restart()
        {
            currentPowerUps = maskManager.currentMask;
            SetCurrentPowerUps();
        }

        void SetCurrentPowerUps()
        {
            DisableAllPowerUps();

            switch (currentPowerUps)
            {
                case 0: // Frog
                    EnableFrogPowerUps();
                    break;
                case 1: // Bear
                    EnableBearPowerUps();
                    break;
                case 2: // Eagle
                    EnableEaglePowerUps();
                    break;
                default:
                    break;
            }
        }

        void DisableAllPowerUps()
        {
            // Frog
            enableFrogPowerUps = false;
            canDoubleJump = false;
            canSwim = false;

            // Bear
            enableBearPowerUps = false;
            canPushObjects = false;
            canClimb = false;

            // Eagle
            enableEaglePowerUps = false;
            canLevitate = false;
            canDash = false;
        }

        void EnableFrogPowerUps()
        {
            enableFrogPowerUps = true;
            canDoubleJump = true;
            canSwim = true;
        }

        void EnableBearPowerUps()
        {
            enableBearPowerUps = true;
            canPushObjects = true;
            canClimb = true;
        }

        void EnableEaglePowerUps()
        {
            enableEaglePowerUps = true;
            canLevitate = true;
            canDash = true;
        }
    }
}