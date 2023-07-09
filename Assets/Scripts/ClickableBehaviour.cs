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
        ClickableBehaviour c;
        bool parentClickable = transform.parent.TryGetComponent<ClickableBehaviour>(out c);
        if (parentClickable)
        {
            c.OnMouseDown();
        }
        else
        {
            clickparticle = GameObject.Find("ClickParticle");
            transform.parent.GetComponent<ClickManager>().active = this;

            clickparticle.transform.position
                = transform.position;//fixed
            clickparticle.GetComponent<ParticleSystem>().Play();
        }

        clickparticle = GameObject.Find("ClickParticle");
        transform.parent.GetComponent<ClickManager>().active = this;
        clickparticle.transform.position 
            = transform.position;//fixed
        clickparticle.GetComponent<ParticleSystem>().Play();
    }

    public abstract void Left(float mag);
    public abstract void Right(float mag);
}
