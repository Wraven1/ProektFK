using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ribalka : MonoBehaviour
{
    public int HPS;
    public int PS;
    public GameObject Saha;
    


    void Start()
    {
        Invoke("Zader", 1f);
        
    }
    void Update()
    {
        if(HPS >= PS)
        {
            Invoke("Smert", 1f);
        }
    }
    void Zader()
    {
        StartCoroutine(Zapolnenie());
    }
    void Smert()
    {
        Destroy(gameObject);
    }


    IEnumerator Zapolnenie()
    {
       
        while (HPS < PS)
        {
            HPS++;
            Instantiate(Saha, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }


    }
}
