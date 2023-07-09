using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject levelselect;
    public GameObject pausemenu;
    public GameObject bg;
    public GameObject winscreen;
    public GameObject start;
    public float level;

    public void UnloadAllScenesExcept(string sceneName = ("UI"))
    {
        int c = SceneManager.sceneCount;
        for (int i = 0; i < c; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name != sceneName)
            {
                SceneManager.UnloadSceneAsync(scene);
            }
        }
    }


    public void win()
    {
        winscreen.SetActive(true);
    }
    public void nextlvl()
    {

        winscreen.SetActive(false);
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name != "UI")
            {
                if (float.TryParse(scene.name, out level))
                {
                    break;
                }
                else
                {
                    Debug.LogError("Unable to parse scene name as a float: " + scene.name);
                }
            }
        }

        level += 1;
        //Debug.Log(winscreen.activeInHierarchy);
        loadscene();
    }

    public void reload()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name != "UI")
            {
                if (float.TryParse(scene.name, out level))
                {
                    break;
                }
                else
                {
                    Debug.LogError("Unable to parse scene name as a float: " + scene.name);
                }
            }
        }

        loadscene();
    }

    public void setlevel(float num)
    {
        level = num;
    }

    public void loadscene()
    {
        if (level != 0)
        {
            UnloadAllScenesExcept();
            SceneManager.LoadScene(level.ToString(), LoadSceneMode.Additive);
            levelselect.SetActive(false);
            bg.SetActive(false);
            Time.timeScale = 1;
        }

        level = 0;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab) && levelselect.activeInHierarchy == false && winscreen.activeInHierarchy == false)
        {
            togglePause();
        }

        if(Input.GetKeyDown(KeyCode.R) && bg.activeInHierarchy == false && winscreen.activeInHierarchy == false)
        {
            reload();
        }
    }

    public void togglePause()
    {
        if(levelselect.activeInHierarchy || start.activeInHierarchy || winscreen.activeInHierarchy)
        {
            return;
        }   
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
            pausemenu.SetActive(true);
            bg.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pausemenu.SetActive(false);
            bg.SetActive(false);
        }
    }

    public void toggleLevelSelect()
    {
        //toggleStart();
        level = 0;
        start.SetActive(levelselect.activeInHierarchy);
        pausemenu.SetActive(false);
        bg.SetActive(false);
        levelselect.SetActive(!levelselect.activeInHierarchy);
        
    }
    public void toggleStart()
    {
        if (start.activeInHierarchy == true)
        {
            levelselect.SetActive(true);
            start.SetActive(false);
        }
        else
        {
            levelselect.SetActive(false);
            start.SetActive(true);
        }
    }

    public void quit()
    {
        Application.Quit();
    }
}
