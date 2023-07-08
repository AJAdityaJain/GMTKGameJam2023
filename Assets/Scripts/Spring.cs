using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : ClickableBehaviour
{
    Animator animationController;

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
                Vector2 direction = -collision.GetContact(0).normal;
                float force = 10f; // Adjust the force as needed

                otherRigidbody.velocity = direction * force;
            }
        }
    }
}