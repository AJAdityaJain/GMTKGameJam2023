using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopManager : MonoBehaviour
{
    int hoopsCount = 0;

    private void Start()
    {
        hoopsCount = transform.childCount;
    }

    public void AddHoops(Hoop h)
    {
        if (h.isActive) { 
            h.isActive = false;
        hoopsCount--;
        if (hoopsCount == 0)
        {
            // Win
            Debug.Log("Win");
        } 
        }
    }
}