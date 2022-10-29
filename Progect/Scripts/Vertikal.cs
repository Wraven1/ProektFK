using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vertikal : MonoBehaviour
{
    public float speed; //эта публичная переменная отобразится в инспекторе, там же мы ее можем и менять. Это очень удобно, чтобы настроить скорость разным слоям картинки

    float pos; //переменная для позиции картинки

    private RawImage image; //создаем объект нашей картинки



    void Start()
    {

        image = GetComponent<RawImage>();//в старте получаем ссылку на картинку

    }



    void Update()
    {

        //в апдейте прописываем как, с какой скоростью и куда мы будем двигать нашу картинку

        pos += speed * Time.deltaTime;

        if (pos > 1.0F)
        {
            pos = 0;
        }

        image.uvRect = new Rect(0, pos, 1, 1);
    }
}
