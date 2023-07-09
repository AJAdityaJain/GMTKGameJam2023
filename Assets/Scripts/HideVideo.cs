using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class HideVideo : MonoBehaviour
{
    private RawImage vidplay;
    public VideoPlayer vp;
    public bool isPlayerStarted = false;

    private void Awake()
    {
        vidplay = GameObject.FindObjectOfType<RawImage>(true);
    }

    void Update()
    {
        if (isPlayerStarted == false && vp.isPlaying == true)
        {
            vidplay.gameObject.SetActive(true);
            isPlayerStarted = true;
        }
        if (isPlayerStarted == true && vp.isPlaying == false)
        {
            vidplay.gameObject.SetActive(false);
        }
    }
}