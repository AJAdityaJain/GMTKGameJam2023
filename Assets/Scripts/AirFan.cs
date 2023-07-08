
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
         transform.GetChild(0).Rotate(Vector3.forward, mag * Time.deltaTime * 10f);
    }

    public override void Right(float mag)
    {
        transform.GetChild(0).Rotate(Vector3.forward, mag * Time.deltaTime * -10f);
    }
}
