using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private UI ui;
    public HoopCounter hc;
    public float SecondsPerish = 7f;
    public float remainingtime;
    private SpriteRenderer self;
    public bool[] hoopsPassed;
    public float hoopsleft;

    private void Awake()
    {
        ui = GameObject.Find("Canvas").GetComponent<UI>();
        hc = GameObject.Find("Hoops").GetComponent<HoopCounter>();
        self = gameObject.GetComponent<SpriteRenderer>();
        remainingtime = SecondsPerish;
        hoopsPassed = new bool[hc.hoopsCount];
        hoopsleft = hc.hoopsCount ;
    }

    public void iWentThroughYou(GameObject hoop)
    {
        int hoopnum = int.Parse(hoop.name);
        if (hoopsPassed[hoopnum] == false)
        {
            hoopsPassed[hoopnum] = true;
            hoopsleft -= 1;
        }
    }

    private void Update()
    {
        if(hoopsleft == 0)
        {
            ui.win();
            hoopsleft = -1;
        }

        remainingtime -= Time.deltaTime;

        Color currentColor = self.color;

        currentColor.a = remainingtime / SecondsPerish;

        self.color = currentColor;

        if (remainingtime <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
