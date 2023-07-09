using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopManager : MonoBehaviour
{
    public UI ui;
    public int hoopsCount = 0;

    private void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<UI>();
        hoopsCount = transform.childCount;
    }

    public void HoopTriggered(Hoop h)
    {
        if (h.isActive)
        { 
            h.isActive = false;
            hoopsCount--;

            if (hoopsCount == 0)
            {
                if (ui != null)
                {
                    // Win
                    Debug.Log("Win");
                    ui.win();
                }
                else
                {
                    ui = GameObject.Find("Canvas").GetComponent<UI>();
                    ui.win();
                }
            } 
        }
    }
}
