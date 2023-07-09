using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(SurfaceEffector2D))]
public class Conveyer : ClickableBehaviour
{
    private enum State
    {
        Speed,
        Direction,
        None
    }
    public List<Sprite> sprites;
    int SpriteIndex = 0;
    public float Speed = 2f;
    [SerializeField]
    State state = State.Direction;
    public int MaxSpeed = 5;
    //float TimePerSprite = 1f;
    //float time;

    private void Start()
    {

        GetComponent<SurfaceEffector2D>().speed = -Speed;
        //TimePerSprite = .75f/Speed;
        StartCoroutine(animate());
    }

    public IEnumerator animate()
    {
        while (true)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[SpriteIndex];

            if (Speed > 0)
                SpriteIndex++;
            else
                SpriteIndex--;

            if (SpriteIndex >= sprites.Count)
            {
                SpriteIndex = 0;
            }
            if (SpriteIndex < 0)
            {
                SpriteIndex = sprites.Count - 1;
            }

            yield return new WaitForSeconds(.25f/Mathf.Abs(Speed));
        }
    }

    public override void Right(float mag)
    {
        Control(mag);
    }

    public override void Left(float mag)
    {
        Control(mag);
    }

    private void Control(float mag)
    {
        if (state == State.Direction)
        {
            Speed = -Mathf.Sign(mag) * Mathf.Abs(Speed);
            GetComponent<SurfaceEffector2D>().speed = -Speed;
        }
        else if (state == State.Speed)
        {
            Speed += mag / 5;
            if (Speed < -MaxSpeed)
                Speed = -MaxSpeed;
            if (Speed > MaxSpeed)
                Speed = MaxSpeed;
            GetComponent<SurfaceEffector2D>().speed = -Speed;
        }
    }
}
