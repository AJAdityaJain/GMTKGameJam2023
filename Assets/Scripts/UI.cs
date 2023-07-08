using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject levelselect;
    public GameObject pausemenu;
    public GameObject bg;
    public float level;

    public void UnloadAllScenesExcept(string sceneName = ("UI"))
    {
        int c = SceneManager.sceneCount;
        for (int i = 0; i < c; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            print(scene.name);
            if (scene.name != sceneName)
            {
                SceneManager.UnloadSceneAsync(scene);
            }
        }
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
            toggleLevelSelect();
            togglePause();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab) && levelselect.activeInHierarchy == false)
        {
            togglePause();
        }
    }

    public void togglePause()
    {
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
        level = 0;
        if (levelselect.activeInHierarchy == true)
        {
            levelselect.SetActive(false);
            pausemenu.SetActive(true);
        }
        else
        {
            levelselect.SetActive(true);
            pausemenu.SetActive(false);
        }
    }
}
