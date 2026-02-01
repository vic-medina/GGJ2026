using System.Collections.Generic;
using UnityEngine;

namespace GGJ2026.Mask
{
    public class MaskManager : MonoBehaviour
    {
        [Header("MaskList")]
        public int currentMask;
        public List<GameObject> maskList = new List<GameObject>();

        [Header("Settings")]
        public float changeMaskCooldown;
        public float cooldownTimer;
        public bool canChangeMask;

        private void Start()
        {
            Restart();
        }

        void Restart()
        {
            currentMask = 0;
            ChangeMask(currentMask);
        }

        private void Update()
        {
            if (!canChangeMask)
            {
                cooldownTimer -= Time.deltaTime;
                if (cooldownTimer <= 0f)
                {
                    canChangeMask = true;
                }
                return;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChangeMask(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ChangeMask(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ChangeMask(2);
            }
        }

        public void ChangeMask(int maskIndex)
        {
            currentMask = maskIndex;
            for (int i = 0; i < maskList.Count; i++)
            {
                if (i == maskIndex)
                {
                    maskList[i].SetActive(true);
                    continue;
                }
                maskList[i].SetActive(false);

                canChangeMask = false;
                cooldownTimer = changeMaskCooldown;
            }
        }
    }
}