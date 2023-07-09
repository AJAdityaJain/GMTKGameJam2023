
using UnityEngine;

public class AirFan : ClickableBehaviour
{
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
        transform.GetChild(0).Rotate(Vector3.forward, mag * Time.deltaTime * 10f * Mathf.Sign(mag));

    }
}
