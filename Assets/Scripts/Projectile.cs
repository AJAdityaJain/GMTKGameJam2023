using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float SecondsPerish = 7f;
    public float remainingtime;
    private SpriteRenderer self;

    private void Awake()
    {
        self = gameObject.GetComponent<SpriteRenderer>();
        remainingtime = SecondsPerish;
    }

    private void Update()
    {
        remainingtime -= Time.deltaTime;

        Color currentColor = self.color;

        currentColor.a = remainingtime / SecondsPerish;

        self.color = currentColor;

        if (remainingtime <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
