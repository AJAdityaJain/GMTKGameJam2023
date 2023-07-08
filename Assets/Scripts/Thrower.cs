using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    public Vector2 Direction = Vector2.up;
    public float SecondsDelay = 2f;
    public GameObject prefab;

    public float time = 0f;

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= SecondsDelay)
        {
            time = 0f;
            var go = Instantiate(prefab, transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = Direction;
        }
    }
}
