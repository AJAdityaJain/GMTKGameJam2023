using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    public AudioSource play;
    public AudioClip hoverFx;
    public AudioClip clickFx;

    public void onHover()
    {
        play.PlayOneShot(hoverFx);
    }

    public void onClick()
    {
        play.PlayOneShot(clickFx);
    }
}
