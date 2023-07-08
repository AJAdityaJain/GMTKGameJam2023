using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : ClickableBehaviour
{
    Animator animationController;
    public float BounceForce = 15f;

    public override void Left(float mag)
    {
        transform.position += mag * Time.deltaTime * Vector3.left;
    }

    public override void Right(float mag)
    {
        transform.position += mag * Time.deltaTime * Vector3.right;
    }

    private void Awake()
    {
        animationController = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.GetContact(0).normal.y < -0.9f)
        {
            animationController.Play("Spring_Launch");

            Rigidbody2D otherRigidbody = collision.collider.GetComponent<Rigidbody2D>();
            if (otherRigidbody != null)
            {
                
                otherRigidbody.AddForce(GetPerpendicular(otherRigidbody.velocity) * BounceForce);
            }
        }
    }

    Vector2 GetPerpendicular(Vector2 vector)
    {
        return new Vector2(-vector.y, vector.x);
    }
}