using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : ClickableBehaviour
{
    private enum State
    {
        Position,
        None
    }
    Animator animationController;
    Rigidbody2D rb;
    public float BounceForce = 15f;

    public override void Left(float mag)
    {
        Control(mag);
    }

    public override void Right(float mag)
    {
        Control(mag);
    }

    private void Control(float mag)
    {
        rb.isKinematic = false;
            rb.velocity = mag * Time.deltaTime * Vector2.right*10;
        rb.isKinematic = true;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

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