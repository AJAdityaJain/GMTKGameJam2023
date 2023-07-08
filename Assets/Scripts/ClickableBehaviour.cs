using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class ClickableBehaviour : MonoBehaviour
{
    private void Update()
    {
        float InputX = Input.GetAxis("Horizontal");

        if(InputX < 0)
        {
            Left(Mathf.Abs  ( InputX));
        }
        else if(InputX > 0)
        {
            Right(Mathf.Abs( InputX));
        }
    }

    public abstract void Left(float mag);
    public abstract void Right(float mag);
}
