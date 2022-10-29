using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObSpayner : MonoBehaviour
{
    public Transform SpawnPos;
    public GameObject Enemy;
    public float taime;
    public float taimeCD;

    void Start()
    {
        StartCoroutine(KultovoeCD()); 
    }
    void Repeat()
    {
        StartCoroutine(SpawnCD());
    }
    IEnumerator KultovoeCD()
    {
        yield return new WaitForSeconds(taimeCD);
        StartCoroutine(SpawnCD());
    }
    IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(taime);
        Instantiate(Enemy, SpawnPos.position, Quaternion.identity);
        Repeat();
    }
    
}
