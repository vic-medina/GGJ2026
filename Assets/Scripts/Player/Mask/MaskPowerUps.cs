using UnityEngine;
using GGJ2026.Ability.Frog;

namespace GGJ2026.Mask
{
    public class MaskPowerUps : MonoBehaviour
    {
        [Header("Setting")]
        public int currentPowerUps;

        [Header("FrogPowerUps")]
        public FrogAbility frogAbility;
        public bool enableFrogPowerUps;

        [Header("BearPowerUps")]
        public BearAbility bearAbility;
        public bool enableBearPowerUps;

        [Header("EaglePowerUps")]
        public EagleAbility eagleAbility;
        public bool enableEaglePowerUps;

        private void Start()
        {
            Restart();
        }

        private void Update()
        {

        }

        void Restart()
        {

        }

        public void SetCurrentPowerUps(int maskIndex)
        {
            currentPowerUps = maskIndex;
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
            frogAbility.enabled = false;
            enableFrogPowerUps = false;

            // Bear
            bearAbility.enabled = false;
            enableBearPowerUps = false;

            // Eagle
            enableEaglePowerUps = false;
            eagleAbility.enabled = false;
        }

        void EnableFrogPowerUps()
        {
            enableFrogPowerUps = true;
            frogAbility.enabled = true;
        }

        void EnableBearPowerUps()
        {
            enableBearPowerUps = true;
            bearAbility.enabled = true;
        }

        void EnableEaglePowerUps()
        {
            eagleAbility.enabled = true;
            enableEaglePowerUps = true;
        }
    }
}