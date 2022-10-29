using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paralacs : MonoBehaviour
{
    public float speed; //эта публичная переменная отобразится в инспекторе, там же мы ее можем и менять. Это очень удобно, чтобы настроить скорость разным слоям картинки
    public float Tame;
    public float ridler;
    public float Maked;
    float pos; //переменная для позиции картинки

    private RawImage image; //создаем объект нашей картинки



    void Start()
    {

        image = GetComponent<RawImage>();//в старте получаем ссылку на картинку
        StartCoroutine(Shetcik());
    }



    void Update()
    {

        //в апдейте прописываем как, с какой скоростью и куда мы будем двигать нашу картинку

        pos += speed * Time.deltaTime;

        if (pos > 1.0F)
        {
            pos = 0;
        }

        image.uvRect = new Rect(pos, 0, 1, 1);
    }
    void Repeat()
    {
     StartCoroutine(Shetcik());
    }
    IEnumerator Shetcik()
    {
        yield return new WaitForSeconds(Tame);
        
        if (ridler < Maked)
        {
            ridler = ridler + 0.0000002f;
            speed = speed + ridler;
        }
        Repeat();
    }
}
