using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Bh : MonoBehaviour
{
    private Animator anim;
    public GameObject BH;
    public Transform SpawnPos;
    public bool canBH;
    public float fulMana;
    public float UsedMana;
    public float OstMana;
    public float speed;
    public GameObject ManaPoll;
    public bool Kalka;
    public bool Prit;
    Transform player;
    public Image abilityImega1;
    public bool Gotovo;
    public float jyldayn;
    private float gohan;
    public Player lox;
    public int Pshag;
    public AudioSource ManaSong;
    public float ShootdMana;
    public bool Kyr;
    public float lapka;
    public GameObject Magiccharge;




    void Start()
    {
        anim = GetComponent<Animator>();
        OstMana = fulMana;
    }
    void Update()
    {

        ManaPoll.transform.localScale = new Vector2(OstMana / fulMana, 1);
        if (Gotovo == true && abilityImega1.fillAmount < 1)
        {
            gohan = 1 / jyldayn;
            abilityImega1.fillAmount += gohan * Time.deltaTime;
        }
    }



    void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Unit").transform;
        if (canBH == true)
        {
            player.position = Vector2.MoveTowards(player.position, transform.position, speed * Time.deltaTime);
        }
        ManaPoll.transform.localScale = new Vector2(OstMana / fulMana, 1);
        

    }
    public void ChargeTikva()
    {
        if (ShootdMana < OstMana && Kyr == false)
        {
            Kyr = true;
            OstMana -= ShootdMana;
            StartCoroutine(Shoot());

        }
    }
    private IEnumerator Shoot()
    {
        Instantiate(Magiccharge, SpawnPos.position, Quaternion.identity);
        yield return new WaitForSeconds(lapka);
        Kyr = false;

    }


    public void HillAspekt()
    {
        if (OstMana >= UsedMana && Kalka == true)
        {
            anim.SetTrigger("Aspekt");
            OstMana = OstMana - UsedMana;
            canBH = true;
            lox.CanYron = false;
            StartCoroutine(KN());
            StartCoroutine(Kyhylin());
        }
    }
    private IEnumerator KN()
    {

        Kalka = false;
        Gotovo = true;
        abilityImega1.fillAmount = 0;
        yield return new WaitForSeconds(jyldayn);
        Kalka = true;
        

    }
    private IEnumerator Kyhylin()
    {

        
        yield return new WaitForSeconds(3.5f);
        lox.CanYron = true;
        canBH = false;


    }
    private IEnumerator Popolnen()
    {
        while (Pshag < 20 && OstMana < fulMana)
        {
            OstMana += 1;
            Pshag++;
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D S)
    {
        
        if (S.gameObject.name.Equals("mana(Clone)"))
        {
            if (OstMana < fulMana)
            {
                ManaSong.Play();
                Pshag = 0;
                StartCoroutine(Popolnen());
                Destroy(S.gameObject);
            }
            else
            {
                Destroy(S.gameObject);
            }

        }
        if (S.gameObject.name.Equals("mana"))
        {
            if (OstMana < fulMana)
            {
                ManaSong.Play();
                Pshag = 0;
                StartCoroutine(Popolnen());
                Destroy(S.gameObject);
            }
            else
            {
                Destroy(S.gameObject);
            }

        }




    }


}
