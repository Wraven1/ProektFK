using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Advertisements;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public bool ReadyJamp;
    public bool ReadyJampDaun;
    public bool Death;
    public bool HillOn;
    public bool Kalka;
    public int JumpForce;
    public int PoolForce;
    public int score;
    public Text sukazaebal;
    public int Spel;
    public Text ScorSpel;
    public Transform SpawnPos;
    public GameObject Magiccharge;
    public bool Kyr;
    public bool canShoot;
    public float Kuldaun;
    public int health;
    public int numOfHearts;
    public int Dophealth;
    public int DopnumOfHearts;
    public int Hill;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public float fulMana;
    public float UsedMana;
    public float ShootdMana;
    public float OstMana;
    public GameObject ManaPoll;
    public bool EvroOn;
    public int PylaOn;
    public Transform SpawnPosAha;
    public GameObject MagicchargeGKA;
    public bool CanYron;
    private Animator anim;
    [Header("Ability 1")]
    public Image abilityImega1;
    public bool Gotovo;
    public float jyldayn;
    private float gohan;
    public GameObject Levels;
    public Text Dengi;
    public Text MenyDengi;
    public int coins;
    public int Dtypa;
    public Interface kor;
    public bool opening;
    public bool Vola;
    public AudioSource coinsSong;
    public AudioSource YronSong;
    public AudioSource ManaSong;
    public int Pshag;
    public bool pillars;
    public int cotik;
    public bool inGame;
    public float speed4;
    public Joystick joystick;
    private Vector2 Movevelocity;
    public bool lala;
    public Vector2 startpos;
    public Vector2 nastpos;
    public float step;
    private float progres;
    private Material matBlink;
    private Material matDefault;
    private SpriteRenderer spriteRend;

    void Start()
    {
       
        cotik = PlayerPrefs.GetInt("c");
        startpos = transform.position;

        if (cotik == 0)
            {
                Dophealth = PlayerPrefs.GetInt("Zdorov");
                health = health + Dophealth;
                numOfHearts = numOfHearts + Dophealth;
            }
            if (cotik == 1)
            {
                Dophealth = PlayerPrefs.GetInt("Zdorov1");
                health = health + Dophealth;
                numOfHearts = numOfHearts + Dophealth;
            }
            if (cotik == 2)
            {
                Dophealth = PlayerPrefs.GetInt("Zdorov2");
                health = health + Dophealth;
                numOfHearts = numOfHearts + Dophealth;
            }
            if (cotik == 3)
            {
                Dophealth = PlayerPrefs.GetInt("Zdorov3");
                health = health + Dophealth;
                numOfHearts = numOfHearts + Dophealth;
            }
            if (cotik == 4)
            {
                Dophealth = PlayerPrefs.GetInt("Zdorov4");
                health = health + Dophealth;
                numOfHearts = numOfHearts + Dophealth;
            }
            if (cotik == 5)
            {
                Dophealth = PlayerPrefs.GetInt("Zdorov5");
                health = health + Dophealth;
                numOfHearts = numOfHearts + Dophealth;
            }
            if (cotik == 6)
            {
                Dophealth = PlayerPrefs.GetInt("Zdorov6");
                health = health + Dophealth;
                numOfHearts = numOfHearts + Dophealth;
            }
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sukazaebal.text = score.ToString();
        MenyDengi.text = score.ToString();
        canShoot = true;
        OstMana = fulMana;
        Vola = true;
        spriteRend = GetComponent<SpriteRenderer>();
        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDefault = spriteRend.material;
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("4163709", false);
        }

        


    }

    public void StatusUp()
    {
        SceneManager.LoadScene(0);
    }
    

    void FixedUpdate()
    {
        if (lala == false)
        {
            Vector2 moveImput = new Vector2(joystick.Horizontal, joystick.Vertical);
            Movevelocity = moveImput.normalized * speed4;
            rb.MovePosition(rb.position + Movevelocity * Time.deltaTime);
        }
        
        if (Kyr == true && canShoot == true)
        {
            anim.SetTrigger("Bamm");
            StartCoroutine(Shoot());
            Kyr = false;
        }

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        
 
        ManaPoll.transform.localScale = new Vector2(OstMana / fulMana, 1);
        
        if (Gotovo == true && abilityImega1.fillAmount < 1)
        {
            gohan = 1 / jyldayn;
            abilityImega1.fillAmount += gohan * Time.deltaTime;
        }
       if(OstMana < fulMana)
        {
            OstMana++;
        }
        if(transform.position.y > 4.5f)
        {  
            rb.AddForce(new Vector2(0, -0.1f));
        }
        if(transform.position.x > 11f)
        {  
            rb.AddForce(new Vector2(-0.1f,0));
        }
         
    }
   
    public void ChargeStraike()
    {
        if (pillars == false)
        {
            if (ShootdMana < OstMana)
            {
                
                Kyr = true;
                OstMana -= ShootdMana;
            }
        }
        else
        {
            Kyr = true;
        }
    }

   
    public void HillAspekt()
    { if (OstMana >= UsedMana && Kalka == true)
        {
            anim.SetTrigger("Aspekt");
            HillOn = true;
            OstMana -= UsedMana;
            StartCoroutine(KH());
        }
    }
    public void EvroAspekt()
    {
        if (OstMana >= UsedMana && Kalka == true)
        {
            EvroOn = true;
            OstMana -= UsedMana;
            StartCoroutine(Evro());
            StartCoroutine(EvroActivite());
        }
    }
    public void PylemetAspekt()
    {
        if (OstMana >= UsedMana && Kalka == true)
        {
            anim.SetTrigger("Aspekt");
            OstMana -= UsedMana;
            abilityImega1.fillAmount = 0;
            StartCoroutine(Pylemet());
            StartCoroutine(PylemetActivite());
        }
    }
    public void KartFokysAspekt()
    {
        if (OstMana >= UsedMana && Kalka == true)
        {
            anim.SetTrigger("Aspekt");
            OstMana -= UsedMana;
            StartCoroutine(Karta());
            StartCoroutine(KartaActivite());
        }
    }
    public void ShitovikAspekt()
    {
        if (OstMana >= UsedMana && Kalka == true)
        {
            anim.SetTrigger("Aspekt");
            OstMana -= UsedMana;
            CanYron = false;
            StartCoroutine(Shit());
            StartCoroutine(ShitActivite());
        }
    }
    
    private  IEnumerator Shoot()
    {
        canShoot = false;
        Instantiate(Magiccharge, SpawnPos.position, Quaternion.identity);
        yield return new WaitForSeconds(Kuldaun);
        canShoot = true;

    }
   
    private IEnumerator KH()
    {

        Kalka = false;
        Gotovo = true;
        abilityImega1.fillAmount = 0;
        yield return new WaitForSeconds(jyldayn);
        Kalka = true;

    }
    private IEnumerator Evro()
    {

        Kalka = false;
        Gotovo = true;
        abilityImega1.fillAmount = 0;
        yield return new WaitForSeconds(jyldayn);
        Kalka = true;

    }
    private IEnumerator Pylemet()
    {

        Kalka = false;
        Gotovo = true;
        abilityImega1.fillAmount = 0;
        yield return new WaitForSeconds(jyldayn);
        Kalka = true;
        PylaOn = 0;

    }
    private IEnumerator PylemetActivite()
    {
        while(PylaOn < 50)
        {
            Instantiate(Magiccharge, SpawnPos.position, Quaternion.identity);
            PylaOn++;
            yield return new WaitForSeconds(0.2f);
        }
    }
    private IEnumerator Karta()
    {

        Kalka = false;
        Gotovo = true;
        abilityImega1.fillAmount = 0;
        yield return new WaitForSeconds(jyldayn);
        Kalka = true;
        PylaOn = 0;

    }
    private IEnumerator KartaActivite()
    {
        while (PylaOn < 3)
        {
            Instantiate(MagicchargeGKA, SpawnPosAha.position, Quaternion.identity);
            PylaOn++;
            yield return new WaitForSeconds(0.3f);
        }
    }
    private IEnumerator Shit()
    {

        Kalka = false;
        Gotovo = true;
        abilityImega1.fillAmount = 0;
        yield return new WaitForSeconds(jyldayn);
        Kalka = true;
        

    }
    private IEnumerator ShitActivite()
    {     
        yield return new WaitForSeconds(20);
        CanYron = true;
        
    }
    
    private IEnumerator EvroActivite()
    {

        anim.SetBool("EvroL", true);
        yield return new WaitForSeconds(25);
        anim.SetBool("EvroL", false);
        EvroOn = false;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (CanYron == true)
        {
            if (collision.gameObject.tag == "DeD")
            {
                YronSong.Play();
                health = health - health;
                if (health == 0)
                {
                    CanYron = false;
                    anim.SetBool("Dai", true);
                    ReadyJamp = false;
                    Death = true;
                    kor.shitaem = false;  
                }
                else
                {
                    anim.SetBool("Dai", false);
                }
            }
            
            if (collision.gameObject.tag == "Unit")
            {
                YronSong.Play();
                health = health - 1;
                spriteRend.material = matBlink;
                Invoke("RestMaterial", 0.2f);
            }
            if (collision.gameObject.tag == "Lil")
            {
                if (health < numOfHearts)
                {
                    health = health + 1;
                }
            }
            if (collision.gameObject.tag == "Boss")
            {
                rb.AddForce(new Vector2(-0.1f, 0));
                YronSong.Play();
                health = health - 1;
                lala = true;
                spriteRend.material = matBlink;
                Invoke("RestMaterial", 0.2f);
                
            }
            if (health == 0)
            {
                CanYron = false;
                anim.SetBool("Dai", true);
                ReadyJamp = false;
                Death = true;
                kor.shitaem = false;
                GetComponent<Rigidbody2D>().gravityScale = 1;
            }
            else
            {
                anim.SetBool("Dai", false);
            }
        }
     
    }
    private void OnTriggerEnter2D(Collider2D S)
    {
        if (EvroOn == true)
        {
            if (S.gameObject.name.Equals("Suka(Clone)"))
            {
                coinsSong.Play();
                score = score + 2;  
                sukazaebal.text = score.ToString();
                MenyDengi.text = score.ToString();
                Destroy(S.gameObject);

            }
        }
        else
        {
            if (S.gameObject.name.Equals("Suka(Clone)"))
            {
                coinsSong.Play();
                score++;
                sukazaebal.text = score.ToString();
                MenyDengi.text = score.ToString();
                Destroy(S.gameObject);
            }
        }

        if (CanYron == true)
        {
            if (S.gameObject.name.Equals("Gnida(Clone)"))
            {
                YronSong.Play();
                health = health - 1;
                spriteRend.material = matBlink;
                Invoke("RestMaterial", 0.2f);
                Destroy(S.gameObject);
                if (health == 0)
                {
                    CanYron = false;
                    anim.SetBool("Dai", true);
                    ReadyJamp = false;
                    Death = true;
                    kor.shitaem = false;
                }
                else
                {
                    anim.SetBool("Dai", false);
                }
            }
        }

    }
    void Update()
    {
        if (Death == true)
        {
            Vola = false;
            Tetris();
            if(coins <= 0)
            {
                Dtypa = Dtypa + score;
                PlayerPrefs.SetInt("con", Dtypa);
                PlayerPrefs.Save();
                coins++;
            }
        }
        if (HillOn == true)
        {
            HillFack();
        }

        Dtypa = PlayerPrefs.GetInt("con");
        Dengi.text = Dtypa.ToString();

    }
    void HillFack()
    {
        StartCoroutine(HillAs());
    }
    IEnumerator HillAs()
    {
        HillOn = false;
        yield return new WaitForSeconds(1.2f);
        health = health + Hill;
    }
    void Tetris()
    {
        StartCoroutine(Smert());
    }
    IEnumerator Smert()
    {
        Death = false;
        lala = true;
        yield return new WaitForSeconds(3);
        Levels.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Bonus()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("Video");
        }
        Time.timeScale = 1f;
        Levels.SetActive(false);
        kor.shitaem = true;
        health = health + numOfHearts;
        Vola = true;
        StartCoroutine(Alaiv());
    }
    IEnumerator Alaiv()
    {
        yield return new WaitForSeconds(1.2f);
        CanYron = true;
    }
    void RestMaterial()
    {
        spriteRend.material = matDefault;
    }

}
