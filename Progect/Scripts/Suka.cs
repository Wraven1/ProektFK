using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suka : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D S)
    {
        if (S.gameObject.name.Equals("Fokys_15"))
        {
            Destroy(gameObject);
        }
    }
}
