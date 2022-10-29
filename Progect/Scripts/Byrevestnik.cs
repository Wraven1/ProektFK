using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Byrevestnik : MonoBehaviour
{

    [SerializeField]
    Transform center;

    [SerializeField]
    float radius = 2f, angularSeed = 2f;
    float positionX, positionY, angle = 0;
    public int peredihka;
    public int PylaOn;
    public int maxP;
    public GameObject Magiccharge;
    public Transform SpawnPos;
    public int timer;
    private Material matBlink;
    private Material matDefault;
    private SpriteRenderer spriteRend;
    public int HP;
    public GameObject HelsPoll;
    public GameObject BossBar;
    public float fulHels;
    private UnityEngine.Object exp;
    public int p;
    public int po;
    public Transform Pos;
    public GameObject Rib;
    public GameObject Dabl;


    void Start()
    {
        maxP = 2;
        StartCoroutine(PylemetActivite());
        spriteRend = GetComponent<SpriteRenderer>();
        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDefault = spriteRend.material;
        exp = Resources.Load("Exp");
    }

    void FixedUpdate()
    {

        if (HP > -1)
        {
            HelsPoll.transform.localScale = new Vector2(HP / fulHels, 1);
            positionX = center.position.x + Mathf.Cos(angle) * radius;
            positionY = center.position.y + Mathf.Sin(angle) * radius;
            transform.position = new Vector2(positionX, positionY);
            angle = angle + Time.deltaTime * angularSeed;

        }
        if (HP <= 0 && p <= 0)
        {
            BossBar.SetActive(false);
            StartCoroutine(SpawnRib());
            PylaOn = maxP;
            p = 3;
        }
        if (HP < 35 && maxP < 4)
        {
            maxP = 4;
        }

        

        if(angle >= 360f)
        {
            angle = 0;
        }
        timer++;
        if(timer > 500)
        {
            PylaOn = 0;
            StartCoroutine(PylemetActivite());
            timer = 0;
        }

        
    }
    private IEnumerator SpawnRib()
    {
        
        while(po < 100)
        {
        po++;
        Instantiate(Rib, Pos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        }
        Instantiate(Dabl, Pos.position, Quaternion.identity);
        GameObject explosionRef = (GameObject)Instantiate(exp);
        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private IEnumerator PylemetActivite()
    {
        while (PylaOn < maxP)
        {
            Instantiate(Magiccharge, SpawnPos.position, Quaternion.identity);
            PylaOn++;
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator retra()
    {
        yield return new WaitForSeconds(0.3f);
        spriteRend.material = matDefault;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Charge")
        {
            HP = HP - 1;
            spriteRend.material = matBlink;
            StartCoroutine(retra());
            Destroy(collision.gameObject);
        }
       

    }
}
