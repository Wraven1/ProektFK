using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Meny : MonoBehaviour
{
    public GameObject Levels;
    public GameObject Panelki;
    public GameObject Panelki2;
    public GameObject Panelki3;
    public GameObject[] levels;
    public Button[] urovni;
    public GameObject[] Butcats;
    public int gnidatypa;
    public int reclam;
    public int jonni;
    public int Logan;
    public int Baton;
    public int Baton1;
    public int Baton2;
    public int Baton3;
    public int Baton4;
    public int Baton5;
    public int dablcat;



    void Start()
    {

        gnidatypa = PlayerPrefs.GetInt("con");
        if (PlayerPrefs.GetInt("j") >= 1)
        {
            Panelki2.SetActive(false);
            urovni[0].interactable = true;
        }
        if (PlayerPrefs.GetInt("L") >= 1)
        {
            Panelki3.SetActive(false);
            urovni[1].interactable = true;
        }
        if (PlayerPrefs.GetInt("B") >= 1)
        {
            levels[0].SetActive(false);
            Butcats[0].SetActive(true);
        }
        if (PlayerPrefs.GetInt("B1") >= 1)
        {
            levels[1].SetActive(false);
            Butcats[1].SetActive(true);
        }
        if (PlayerPrefs.GetInt("B2") >= 1)
        {
            levels[2].SetActive(false);
            Butcats[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("B3") >= 1)
        {
            levels[3].SetActive(false);
            Butcats[3].SetActive(true);
        }
        if (PlayerPrefs.GetInt("B4") >= 1)
        {
            levels[4].SetActive(false);
            Butcats[4].SetActive(true);
        }
        if (PlayerPrefs.GetInt("B5") >= 1)
        {
            levels[5].SetActive(false);
            Butcats[5].SetActive(true);
        }
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("4163709", false);
        }
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Panelki.SetActive(false);
        }
        if(jonni > 0)
        {
            Panelki2.SetActive(false);
        }
        if (Logan > 0)
        {
            Panelki3.SetActive(false);
        }
       
        jonni = PlayerPrefs.GetInt("j");
        Logan = PlayerPrefs.GetInt("L");
        Baton = PlayerPrefs.GetInt("B");
        Baton1 = PlayerPrefs.GetInt("B1");
        Baton2 = PlayerPrefs.GetInt("B2");
        Baton3 = PlayerPrefs.GetInt("B3");
        Baton4 = PlayerPrefs.GetInt("B4");
        Baton5 = PlayerPrefs.GetInt("B5");
        reclam = PlayerPrefs.GetInt("reclama1");
        
    }
    public void OneEsc()
    {
        Panelki.SetActive(false);
    }
    

    public void OnClickStart()
    {
        Levels.SetActive(true);
        Panelki.SetActive(false);
    }
    public void OnClickPanel()
    {
        
        Panelki.SetActive(true);
        Levels.SetActive(false);
    }
    public void Clic2()
    {
        if (gnidatypa >= 1500)
        {
            gnidatypa = gnidatypa - 1500;
            PlayerPrefs.SetInt("con", gnidatypa);
            PlayerPrefs.Save();
            Panelki2.SetActive(false);
            urovni[0].interactable = true;
            jonni = 1;
            PlayerPrefs.SetInt("j", jonni);
            PlayerPrefs.Save();
        }
    }
    public void Clic4()
    {
        if (gnidatypa >= 3000)
        {
            gnidatypa = gnidatypa - 3000;
            PlayerPrefs.SetInt("con", gnidatypa);
            PlayerPrefs.Save();
            Panelki3.SetActive(false);
            urovni[1].interactable = true;
            Logan = 1;
            PlayerPrefs.SetInt("L", Logan);
            PlayerPrefs.Save();
        }
    }
    public void Clic3()
    {
       // if (Advertisement.IsReady())
       // {
        //   Advertisement.Show("Video");
       // }
        gnidatypa = gnidatypa + 150;
        PlayerPrefs.SetInt("con", gnidatypa);
        PlayerPrefs.Save();
        
    }
    public void OneClickExit()
    {
        Application.Quit();
    }
    public void levelButtons(int level)
    {
       // if (reclam < 7)
         //  {
           // reclam = reclam + 1;
           // PlayerPrefs.SetInt("reclama1", reclam);
           // PlayerPrefs.Save();
           SceneManager.LoadScene(level);
         //  }
     //   else
       // {
       //     if (Advertisement.IsReady())
         //   {
           //     Advertisement.Show("Video");
          //  }
          //  reclam = reclam - 7;
          //  PlayerPrefs.SetInt("reclama1", reclam);
          //  PlayerPrefs.Save();
            
       // }    
    }
    
    
    public void OtkritieCotikov()
    {
        if (gnidatypa >= 500 )
        {
            gnidatypa = gnidatypa - 500;
            PlayerPrefs.SetInt("con", gnidatypa);
            PlayerPrefs.Save();
            levels[0].SetActive(false);
            Butcats[0].SetActive(true);
            Baton = 1;
            PlayerPrefs.SetInt("B", Baton);
            

        }
      
    }
    public void OtkritieCotikov1()
    {
        if (gnidatypa >= 750 )
        {
            gnidatypa = gnidatypa - 750;
            PlayerPrefs.SetInt("con", gnidatypa);
            PlayerPrefs.Save();
            levels[1].SetActive(false);
            Butcats[1].SetActive(true);
            Baton1 = 2;
            PlayerPrefs.SetInt("B1", Baton1);
            

        }
    }
    public void OtkritieCotikov2()
    {
        if (gnidatypa >= 900 )
        {
            gnidatypa = gnidatypa - 900;
            PlayerPrefs.SetInt("con", gnidatypa);
            PlayerPrefs.Save();
            levels[2].SetActive(false);
            Butcats[2].SetActive(true);
            Baton2 = 3;
            PlayerPrefs.SetInt("B2", Baton2);
            PlayerPrefs.Save();

        }
    }
    public void OtkritieCotikov3()
    {
        if (gnidatypa >= 1250 )
        {
            gnidatypa = gnidatypa - 1250;
            PlayerPrefs.SetInt("con", gnidatypa);
            PlayerPrefs.Save();
            levels[3].SetActive(false);
            Butcats[3].SetActive(true);
            Baton3 = 4;
            PlayerPrefs.SetInt("B3", Baton3);
            PlayerPrefs.Save();

        }
    }
    public void OtkritieCotikov4()
    {
        if (gnidatypa >= 1500 )
        {
            gnidatypa = gnidatypa - 1500;
            PlayerPrefs.SetInt("con", gnidatypa);
            PlayerPrefs.Save();
            levels[4].SetActive(false);
            Butcats[4].SetActive(true);
            Baton4 = 5;
            PlayerPrefs.SetInt("B4", Baton4);
            PlayerPrefs.Save();

        }
    }
    public void OtkritieCotikov5()
    {
        if (gnidatypa >= 1700 )
        {
            gnidatypa = gnidatypa - 1700;
            PlayerPrefs.SetInt("con", gnidatypa);
            PlayerPrefs.Save();
            levels[5].SetActive(false);
            Butcats[5].SetActive(true);
            Baton5 = 6;
            PlayerPrefs.SetInt("B5", Baton5);
            PlayerPrefs.Save();

        }
    }
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
