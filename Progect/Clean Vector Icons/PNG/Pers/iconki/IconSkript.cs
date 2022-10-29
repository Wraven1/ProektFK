using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Advertisements;

public class IconSkript : MonoBehaviour
{
    public Image h;
    public Sprite[] hearts;
    public int a;

    void Start()
    {
        a = PlayerPrefs.GetInt("c");
    }

    // Update is called once per frame
    void Update()
    {
      h.sprite = hearts[a];
    }
}
