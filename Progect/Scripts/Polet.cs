using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polet : MonoBehaviour
{
    public float speed;
    public Vector2 dir;
    public bool kek;
    void Start()
    {
        StartCoroutine(Smert());
    }

    // Update is called once per frame
    void Update()
    {
        if(kek == true)
        {
            transform.Translate(dir * speed, Space.World);
        }
    }
    private IEnumerator Smert()
    {
        yield return new WaitForSeconds(1);
        kek = true;
        
    }
}
