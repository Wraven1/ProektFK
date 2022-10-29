using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Pauza : MonoBehaviour

{
    public GameObject Pahka;
    public bool harakter;

   
    public void PauseButtons()
    {
        Pahka.SetActive(true);
        harakter = false;
        Time.timeScale = 0f;
    }
    public void SnovaButtons()
    {
        if (harakter == false)
        {
            Pahka.SetActive(false);
            Time.timeScale = 1f;
            harakter = true;
        }
    }
    public void MenuButtons()
    {
        if (harakter == false)
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
            harakter = true;
        }
    }
    public void levelButtons(int level)
    {
        if (harakter == false)
        {
            SceneManager.LoadScene(level);
            Time.timeScale = 1f;
            harakter = true;
        }
    }

    public void ButtonInGO(int level)
    {
     SceneManager.LoadScene(level);
     Time.timeScale = 1f;   
    }


}
