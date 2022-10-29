using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Kathc : MonoBehaviour
{
    public string product;
    public int gnidatypa;
    public int gnidatypa2;
    public int gnidatypa3;
    public int Limit;
    public Text Debil;

    void Start()
    {
        gnidatypa2 = PlayerPrefs.GetInt(product);
        gnidatypa2 = gnidatypa2*gnidatypa3 + gnidatypa3;

    }
    void Update()
    {
        gnidatypa = PlayerPrefs.GetInt("con");
        Debil.text = gnidatypa2.ToString();
        
    }

    public void productUp()
    {
        int count = PlayerPrefs.GetInt(product);
        
        if (gnidatypa > gnidatypa2 && count <= Limit)
        { 
            gnidatypa -= gnidatypa2;
            PlayerPrefs.SetInt("con", gnidatypa);
            PlayerPrefs.SetInt(product, count + 1);
       
        }
 
    }
}
