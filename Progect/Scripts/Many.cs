using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Many : MonoBehaviour
{
    public GameObject any;
    public int taimer;

    void Start()
    {
        StartCoroutine(Spawner());
    }
    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(taimer);
            float rand = Random.Range(-2f, 4f);
            Instantiate(any, new Vector3(15, rand, 0), Quaternion.identity);
        }
    }
}
