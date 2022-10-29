using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour
{
    public int skor;
    public int record;
    public int record1;
    public int record2;
    public int record3;
    public int gnidatypa;
    public int NamberLoc;
    public float Tame;
    public bool shitaem;
    public Text skorT;
    public Text menyScor;
    public Text menyRecord;
    public GameObject[] cats;
    public GameObject[] spels;
    public GameObject[] Achivki;
    public MoveEnemy lera;
    public MoveEnemy lampa;
    public MoveEnemy lama;
    public float kapa;
    public Text MenyDengi;
    public GameObject Levels;
    public int Baton1;
    public int Baton2;
    public int Baton3;
    public int Baton4;
    public int Baton5;
    public GameObject Boss;
    public GameObject BossHP;
    public int DopHP;
    public int dablcat;
    public GameObject[] spauners;


    void Start()
    {
        dablcat = PlayerPrefs.GetInt("c"); 
        cats[PlayerPrefs.GetInt("c")].SetActive(true);
        spels[PlayerPrefs.GetInt("c")].SetActive(true);
        StartCoroutine(Shetcik());
        

    }
    void Update()
    {

        if (skor == 100)
        {
            Boss.SetActive(true);
            BossHP.SetActive(true);
            for (int i = 0; i < spauners.Length; i++)
            {
                spauners[i].SetActive(false);
            }
            
        }
        
        if (NamberLoc == 1)
        {
            if (skor > record)
            {
                record = skor;
                PlayerPrefs.SetInt("rec1", record);
                PlayerPrefs.Save();
            }
            record = PlayerPrefs.GetInt("rec1");
            menyRecord.text = record.ToString();
        }
        if (NamberLoc == 2)
        {
            if (skor > record)
            {
                record = skor;
                PlayerPrefs.SetInt("rec2", record);
                PlayerPrefs.Save();
            }
            record = PlayerPrefs.GetInt("rec2");
            menyRecord.text = record.ToString();
        }
        if (NamberLoc == 3)
        {
            if (skor > record)
            {
                record = skor;
                PlayerPrefs.SetInt("rec3", record);
                PlayerPrefs.Save();
            }
            record = PlayerPrefs.GetInt("rec3");
            menyRecord.text = record.ToString();
        }
        if (Levels.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            Levels.SetActive(false);
        }
        gnidatypa = PlayerPrefs.GetInt("con");
        Baton1 = PlayerPrefs.GetInt("But1");
        Baton2 = PlayerPrefs.GetInt("But2");
        Baton3 = PlayerPrefs.GetInt("But3");
        Baton4 = PlayerPrefs.GetInt("But4");
        Baton5 = PlayerPrefs.GetInt("But5");
        record1 = PlayerPrefs.GetInt("rec1");
        record2 = PlayerPrefs.GetInt("rec2");
        record3 = PlayerPrefs.GetInt("rec3");

        if (Baton1 >= 1)
        {
            Achivki[0].SetActive(false);
        }
        if (PlayerPrefs.GetInt("But2") >= 1)
        {
            Achivki[1].SetActive(false);

        }
        if (PlayerPrefs.GetInt("But3") >= 1)
        {
            Achivki[2].SetActive(false);

        }
        if (PlayerPrefs.GetInt("But4") >= 1)
        {
            Achivki[3].SetActive(false);

        }
        if (PlayerPrefs.GetInt("But5") >= 1)
        {
            Achivki[4].SetActive(false);

        }

    }
    public void Pluss()
    {
        if (dablcat < 6)
        {
            cats[PlayerPrefs.GetInt("c")].SetActive(false);
            PlayerPrefs.GetInt("c", dablcat);
            dablcat++;
            PlayerPrefs.SetInt("c", dablcat);
            PlayerPrefs.Save();
            cats[PlayerPrefs.GetInt("c")].SetActive(true);
        }

    }
    public void Minys()
    {
        if (dablcat > 0)
        {
            cats[PlayerPrefs.GetInt("c")].SetActive(false);
            PlayerPrefs.GetInt("c", dablcat);
            dablcat--;
            PlayerPrefs.SetInt("c", dablcat);
            PlayerPrefs.Save();
            cats[PlayerPrefs.GetInt("c")].SetActive(true);
        }

    }


    public void Ach1()
    {
        if (record1 >= 500)
        {
            gnidatypa = gnidatypa + 250;
            PlayerPrefs.SetInt("con", gnidatypa);
            PlayerPrefs.Save();
            Achivki[0].SetActive(false);
            Baton1 = 1;
            PlayerPrefs.SetInt("But1", Baton1);
            PlayerPrefs.Save();

        }

    }
    public void Ach2()
    {
        if (record1 >= 1000)
        {
            gnidatypa = gnidatypa + 500;
            PlayerPrefs.SetInt("con", gnidatypa);
            PlayerPrefs.Save();
            Achivki[1].SetActive(false);
            Baton2 = 1;
            PlayerPrefs.SetInt("But2", Baton2);
            PlayerPrefs.Save();

        }

    }
    public void Ach3()
    {
        if (record2 >= 500)
        {
            gnidatypa = gnidatypa + 350;
            PlayerPrefs.SetInt("con", gnidatypa);
            PlayerPrefs.Save();
            Achivki[2].SetActive(false);
            Baton3 = 1;
            PlayerPrefs.SetInt("But3", Baton3);
            PlayerPrefs.Save();

        }

    }
    public void Ach4()
    {
        if (record2 >= 1000)
        {
            gnidatypa = gnidatypa + 700;
            PlayerPrefs.SetInt("con", gnidatypa);
            PlayerPrefs.Save();
            Achivki[3].SetActive(false);
            Baton4 = 1;
            PlayerPrefs.SetInt("But4", Baton4);
            PlayerPrefs.Save();

        }
    }
    public void Ach5()
    {
        if (record3 >= 1000)
        {
            gnidatypa = gnidatypa + 1000;
            PlayerPrefs.SetInt("con", gnidatypa);
            PlayerPrefs.Save();
            Achivki[4].SetActive(false);
            Baton5 = 1;
            PlayerPrefs.SetInt("But5", Baton5);
            PlayerPrefs.Save();

        }
    }
    public void OnClickStart()
    {
        Levels.SetActive(true);
    }
    
    void Repeat()
    {   
     StartCoroutine(Shetcik());
    }
    IEnumerator Shetcik()
    {
        yield return new WaitForSeconds(Tame);
        skor++;
        skorT.text = skor.ToString();
        menyScor.text = skor.ToString();

        if (kapa < 0.15f)
        {
         kapa = kapa + 0.0002f;
         lera.lerysik = kapa;
         lampa.lerysik = kapa;
         lama.lerysik = kapa;
        }
        Repeat();
    }
    

}
