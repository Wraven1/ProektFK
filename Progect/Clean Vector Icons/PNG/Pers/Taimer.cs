using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRib());
    }

    // Update is called once per frame
    
    
        private IEnumerator SpawnRib()
        {

            
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
    
}
