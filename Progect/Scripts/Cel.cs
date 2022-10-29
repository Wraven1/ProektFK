using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shetcik());
    }

    IEnumerator Shetcik()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }
}
