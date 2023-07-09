using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    public bool isActive = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponentInParent<HoopManager>().HoopTriggered(this);
    }
}
