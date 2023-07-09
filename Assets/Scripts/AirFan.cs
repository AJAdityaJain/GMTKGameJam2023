
using UnityEngine;

public class AirFan : ClickableBehaviour
{

    private enum State
    {
        Rotation,
        None
    }

    public float rotationSpeed = 100f;
    public float minZRotation = -180f;
    public float maxZRotation = 0f;

    [SerializeField]
    State state = State.Rotation;

    public float Force = 15f;
    
    private void Start()
    {
        transform.GetChild(0).GetComponent<AreaEffector2D>().forceMagnitude = -Force;
    }

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
        if (state == State.Rotation)
        {
            //float sign = Mathf.Sign(mag);
            //if ((sign == -1 && transform.GetChild(0).transform.rotation.z > -AngleConstraint))
            //    transform.GetChild(0).Rotate(Vector3.forward, mag * Time.deltaTime * 50f);
            //if ((sign == 1 && transform.GetChild(0).transform.rotation.z < 0))
            //    transform.GetChild(0).Rotate(Vector3.forward, mag * Time.deltaTime * 50f);
            Transform T =
transform.GetChild(0).transform;
    Quaternion targetRotation = Quaternion.Euler(T.rotation.eulerAngles.x, T.rotation.eulerAngles.y, Mathf.Clamp(T.rotation.eulerAngles.z + (-mag * Time.deltaTime * rotationSpeed), minZRotation, maxZRotation));
            T.rotation = targetRotation;
        }
    }
}
