using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    Animator anim;
    public Vector2 Direction = Vector2.up;
    public float Magnitude = 10f;
    public float SecondsDelay = 2f;
    public GameObject prefab;
    public Transform BallTransform;
    public float instanceamount;

    public float time = 0f;

    private void Start()
    {
        time = 0.7f * SecondsDelay;    
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= SecondsDelay)
        {

            time = 0f;
            anim.Play("Jeff_Throw");
            StartCoroutine(UpdateCOur());
        }
    }

    private IEnumerator UpdateCOur()
    {

        yield return new WaitForSeconds(0.2f);
        var go = Instantiate(prefab, BallTransform.position, Quaternion.Euler(0f, 0, Random.Range(0, 360)));
        go.transform.parent = gameObject.transform;
        go.GetComponent<Rigidbody2D>().velocity = Direction.normalized * Magnitude;
        go.name = "paperball " + instanceamount.ToString();
        instanceamount += 1;

    }
}
