using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mexa : MonoBehaviour
{
    public GameObject HelsPoll;
    public GameObject BossBar;
    public float HP;
    public float fulHels;
    public int p;
    public GameObject Rib;
    public GameObject Hilka;
    public Transform Pos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP > -1)
        {
            HelsPoll.transform.localScale = new Vector2(HP / fulHels, 1);
        }
        if (HP <= 0 && p <= 0)
        {
            Instantiate(Rib, Pos.position, Quaternion.identity);
            BossBar.SetActive(false);
            p = 3;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Lil")
        {
            HP = HP - 1;
            Instantiate(Hilka, Pos.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
        

    }
}
