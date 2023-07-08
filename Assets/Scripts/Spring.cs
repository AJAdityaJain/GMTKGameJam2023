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
        if (collision.GetContact(0).normal.y < -.9f)
        {
            animationController.ResetTrigger("Launch 0");
            animationController.SetTrigger("Launch 0");
        }
    }
}