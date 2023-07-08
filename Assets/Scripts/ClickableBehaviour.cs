using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class ClickableBehaviour : MonoBehaviour
{
    private GameObject clickparticle;

    private void Update()
    {
        clickparticle = GameObject.Find("ClickParticle");
        if (clickparticle == null)
            Debug.LogError("ClickParticle not found");
    }

    private void OnMouseDown()
    {
        transform.parent.GetComponent<ClickManager>().active = this;
        clickparticle.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickparticle.GetComponent<ParticleSystem>().Play();
    }

    public abstract void Left(float mag);
    public abstract void Right(float mag);
}
