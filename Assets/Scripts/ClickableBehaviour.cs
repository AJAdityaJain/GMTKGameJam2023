using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class ClickableBehaviour : MonoBehaviour
{
    private GameObject clickparticle;

    private void Start()
    {
        clickparticle = GameObject.Find("ClickParticle");
        if (clickparticle == null)
            Debug.LogError("ClickParticle not found");
    }

    //private void Update()
    //{
     //   if (clickparticle == null)
         //   clickparticle = GameObject.Find("ClickParticle");
  //  }

    public void OnMouseDown()
    {
        if (transform.parent.TryGetComponent<ClickableBehaviour>(out ClickableBehaviour cb))
        {
            cb.OnMouseDown();
        }
        else if (transform.parent.TryGetComponent<ClickManager>(out ClickManager cm))
        {
            if (cm.gameObject.activeInHierarchy)
            {
                transform.parent.GetComponent<ClickManager>().active = this;
                clickparticle = GameObject.Find("ClickParticle");
                clickparticle.transform.position
                    = transform.position;//fixed
                clickparticle.GetComponent<ParticleSystem>().Play();
            }
        }

    }

    public abstract void Left(float mag);
    public abstract void Right(float mag);
}
