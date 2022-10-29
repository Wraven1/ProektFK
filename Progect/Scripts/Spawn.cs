using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform SpawnPos;
    public GameObject Enemy;
    public float Time;
    public GameObject any;
    public float taimer;
    public GameObject star;
    public float tamer;
    public bool plauza;




    void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(Spawner());
        StartCoroutine(Staker());
    }


    void Repeat()
    {
        if (plauza == true)
        {
            StartCoroutine(SpawnEnemy());
            
        }
    }
    void Repa()
    {
        if (plauza == true)
        {
            StartCoroutine(Spawner());

        }
    }
    void Repara()
    {
        if (plauza == true)
        {
            StartCoroutine(Staker());

        }
    }
    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(Time);
        float pok = Random.Range(-1f, 3f);
        Instantiate(Enemy, new Vector3(12, pok, 0), Quaternion.identity);
        Repeat();
    }
    IEnumerator Spawner()
    {
            yield return new WaitForSeconds(taimer);
            float rand = Random.Range(-2f, 4f);
            Instantiate(any, new Vector3(12, rand, 0), Quaternion.identity);
            Repa();
       
    }
    IEnumerator Staker()
    {
        yield return new WaitForSeconds(60);
        if (Time > 1f && taimer > 1f)
        {
            Time = Time - 0.5f;
            taimer = taimer - 0.5f;
            Repara();
        }

    }


}
