using System.Collections.Generic;
using UnityEngine;

public class MaskManagerF : MonoBehaviour
{
    public int currentMask;
    public List<GameObject> maskList = new List<GameObject>();

    void Restart()
    {
        currentMask = 0;
        ChangeMask(currentMask);
    }

    private void Update()
    {
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
            if(i == maskIndex)
            {
                maskList[i].SetActive(true);
                continue;
            }
            maskList[i].SetActive(false);
        }
    }
}
