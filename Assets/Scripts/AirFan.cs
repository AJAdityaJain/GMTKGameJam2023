
using UnityEngine;

public class AirFan : ClickableBehaviour
{
    public override void Left(float mag)
    {
         transform.GetChild(0).Rotate(Vector3.forward, mag * Time.deltaTime * 10f);
    }

    public override void Right(float mag)
    {
        transform.GetChild(0).Rotate(Vector3.forward, mag * Time.deltaTime * -10f);
    }
}
