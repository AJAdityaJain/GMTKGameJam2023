using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    public bool isActive = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile paperball = collision.gameObject.GetComponent<Projectile>();
        if (paperball != null)
            paperball.iWentThroughYou(gameObject);
    }
}
