using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class ClickableBehaviour : MonoBehaviour
{
    private void OnMouseDown()
    {
        transform.parent.GetComponent<ClickManager>().active = this;
    }

    public abstract void Left(float mag);
    public abstract void Right(float mag);
}
