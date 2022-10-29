using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luch : MonoBehaviour
{
    public GameObject HelsPoll;
    public float HP;
    public float fulHels;
    void Start()
    {
        StartCoroutine(SpawnSard());
    }

    // Update is called once per frame
    void Update()
    {
        HP = HP - 5;
        HelsPoll.transform.localScale = new Vector2(HP / fulHels, 2);
    }
    IEnumerator SpawnSard()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
