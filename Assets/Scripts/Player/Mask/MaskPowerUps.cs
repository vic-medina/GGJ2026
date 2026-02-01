using UnityEngine;
using GGJ2026.Ability.Frog;
using GGJ2026.Player.BaseMovement;

namespace GGJ2026.Mask
{
    public class MaskPowerUps : MonoBehaviour
    {
        [Header("References")]
        public MovementController movController;
        public Animator anim;

        [Header("Setting")]
        public int currentPowerUps;

        [Header("Animator Controllers")]
        public RuntimeAnimatorController frogController;
        public RuntimeAnimatorController bearController;
        public RuntimeAnimatorController eagleController;

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
            SetCurrentPowerUps(0);
        }

        public void SetCurrentPowerUps(int maskIndex)
        {
            currentPowerUps = maskIndex;
            DisableAllPowerUps();

            switch (currentPowerUps)
            {
                case 0: // Frog
                    EnableFrogPowerUps();
                    anim.runtimeAnimatorController = frogController;
                    break;
                case 1: // Bear
                    EnableBearPowerUps();
                    anim.runtimeAnimatorController = bearController;
                    break;
                case 2: // Eagle
                    EnableEaglePowerUps();
                    anim.runtimeAnimatorController = eagleController;
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