using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float SecondsPerish = 7f;

    private void Update()
    {
        SecondsPerish -= Time.deltaTime;
        if (SecondsPerish <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
