using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SurfaceEffector2D))]
public class Conveyer : ClickableBehaviour
{
    public List<Sprite> sprites;
    int SpriteIndex = 0;
    public float Speed = 2f;
    float TimePerSprite = 1f;
    float time = 0f;

    private void Start()
    {
        GetComponent<SurfaceEffector2D>().speed = -Speed;
        TimePerSprite = .25f/Speed;
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= TimePerSprite)
        {
            time -= TimePerSprite;

            GetComponent<SpriteRenderer>().sprite = sprites[SpriteIndex];
            
            if(Speed > 0)
                SpriteIndex++;
            else
                SpriteIndex--;

            if (SpriteIndex >= sprites.Count)
            {
                SpriteIndex = 0;
            }
            if(SpriteIndex < 0)
            {
                SpriteIndex = sprites.Count - 1;
            }
        }
    }

    public override void Left(float mag)
    {
        Speed = -Mathf.Abs(Speed);
        Start();
    }

    public override void Right(float mag)
    {
        Speed = Mathf.Abs(Speed);
        Start();
    }
}
