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
        ClickableBehaviour parentClickable = transform.parent.GetComponent<ClickableBehaviour>();
        if (parentClickable != null)
        {
            parentClickable.OnMouseDown();
        }
        else
        {
            clickparticle = GameObject.Find("ClickParticle");
            Debug.Log(clickparticle.transform);
            transform.parent.GetComponent<ClickManager>().active = this;
            clickparticle.transform.position
                = transform.position;//fixed
            clickparticle.GetComponent<ParticleSystem>().Play();
        }
    }

    public abstract void Left(float mag);
    public abstract void Right(float mag);
}
