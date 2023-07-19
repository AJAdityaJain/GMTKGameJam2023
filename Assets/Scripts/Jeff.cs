using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LineRenderer))]
public class Jeff : MonoBehaviour
{
    //YES i named hi jeff


    public Animator animator;

    public GameObject Test;

    LineRenderer lr;

    public int LineSize;
    public float g = -1f;
    public float scale = 10f;
    public float maxVelocity = 30;

    public Transform BallTransform;
    Vector3 downLoc = Vector3.zero;
    bool isDown = false;


    private void Start()
    {
        animator = GetComponent<Animator>();
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (isDown)
            {
                Vector2 v = (downLoc - Input.mousePosition) / scale;
                if (v.magnitude > maxVelocity)
                {
                    v = v.normalized * maxVelocity;
                }
                lr.positionCount = LineSize;
                int s = (2 * PlayerPrefs.GetInt("invert")) - 1;

                for (int i = 0; i < LineSize; i++)
                {
                    float x = transform.position.x + (v.x * i * s) / (g * Physics.gravity.y);
                    float y = transform.position.y + ((v.y * i * s) + (0.5f * g * i * i)) / (g * Physics.gravity.y);
                    lr.SetPosition(i, new Vector3(x, y, 0));
                }
            }
            else
            {
                lr.positionCount = 0;
            }
            if (Input.GetMouseButtonDown(0) && !isDown)
            {
                isDown = true;
                downLoc = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0) && isDown)
            {
                isDown = false;
                var vel = (downLoc - Input.mousePosition) / scale;

                if (vel.magnitude > 4)
                {
                    animator.Play("Jeff_Throw");
                    StartCoroutine(WaitInstanciate(vel));
                }
            }
        }
    }

    public IEnumerator WaitInstanciate(Vector2 vel)
    {
        yield return new WaitForSeconds(0.2f);
        GameObject go;
        go = Instantiate(Test);
        go.transform.parent = gameObject.transform;

        go.transform.position = BallTransform.position;
        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
        rb.velocity = vel;
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
        rb.velocity *= (2 * PlayerPrefs.GetInt("invert")) - 1;

    }
}
