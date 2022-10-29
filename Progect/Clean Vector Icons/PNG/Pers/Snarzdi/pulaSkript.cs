using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulaSkript : MonoBehaviour
{
    private UnityEngine.Object exp;
    void Start()
    {
        exp = Resources.Load("Pula");
        GameObject explosionRef = (GameObject)Instantiate(exp);
        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    
}
