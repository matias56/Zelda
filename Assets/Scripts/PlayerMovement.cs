using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector3 change;
    private Animator anim;
    public AudioSource lsound;
    public AudioClip lose;
    public VectorValue vv;
    public Transform shield;
    public Vector3 mov;
    public Vector2 dir;
    public bool attack;
    public static float health = 3;
    public int maxHealth = 3;
    public GameObject swordShoot;
    public float timer = 1f;
    public float initTimer = 1f;
    public float swSpeed = 10f;
    public SWPR s;
    public float Sspeed = 10f;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public float numH;
    public Transform attPoint;
    public float attRange = 0.5f;
    public LayerMask enemies;
    public float att = 1;
    public Text rup;
    public Text bom;
    public Image sw;
    public Sprite wS;
    public Text tri;
    public Text keys;
    public Text bKeys;
    public static bool tS;
    public float stopTime = 3;
    public TimeManager tm;
    public float fr = 0;
    public Octorock[] eneMies;
    public Spider[] spi;
    public Fly[] fly;
    public Slime[] slime;
    public bool stopT  = false;
    public Image bow;
    public Image letter;
    public Image raft;
    public Image ladder;
    public Image book;
    public Image bRing;
    public Image rRing;
    public Image bracelet;
    public float itemTime = 2f;
    public GameObject bomb;

    public float kbForce;
    public float kbCounter;
    public float kbTotal;

    public bool knockRight;

    public bool knockUp;

    public Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        transform.position = vv.initValue;
        eneMies = FindObjectsOfType<Octorock>();
        spi = FindObjectsOfType<Spider>();
        fly = FindObjectsOfType<Fly>();
        slime = FindObjectsOfType<Slime>();
        stopT = false;


        kbCounter = 0;

        knockRight = false;
        knockUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");

        anim.SetFloat("MoveX", rb.velocity.x);
        anim.SetFloat("MoveY", rb.velocity.y);
        mov = new Vector3(dirX, dirY).normalized;
       
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            anim.SetFloat("LMX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("LMY", Input.GetAxisRaw("Vertical"));
            shield.position = transform.position + mov.normalized;
            shield.rotation = this.transform.rotation;
            attPoint.position = transform.position + mov.normalized;
            attPoint.rotation = this.transform.rotation;

        }

        if (dirX < 0)
        {
            shield.transform.rotation = Quaternion.Euler(0, 0, 90);
            attPoint.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (dirX > 0)
        {
            shield.transform.rotation = Quaternion.Euler(0, 0, -90);
            attPoint.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (dirY>0)
        {
            shield.transform.rotation = Quaternion.Euler(0, 0, 0);
            attPoint.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (dirY < 0)
        {
            shield.transform.rotation = Quaternion.Euler(0, 0, 180);
            attPoint.transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        if (PlayerProfile.hasSword && Input.GetKeyDown(KeyCode.Z) && timer > initTimer)
        {
            anim.SetTrigger("Att");
            Attack();
            timer = 0;
        }

        timer += Time.deltaTime;

        s.rb.velocity = this.dir;

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i <= health -1)
            {
                hearts[i].sprite = fullHeart;
            }
            else  if(i >= health)
            {
                hearts[i].sprite = emptyHeart;
            }
            else
            {
                hearts[i].sprite = halfHeart;
            }

            if(i<maxHealth)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
        }

        if(health > maxHealth)
        {
            health = maxHealth;
        }

        rup.text = PlayerProfile.rupees.ToString();

        bom.text = PlayerProfile.bombs.ToString();

        keys.text = PlayerProfile.keys.ToString();

        bKeys.text = PlayerProfile.mKeys.ToString();

        if(PlayerProfile.hasSword)
        {
            sw.sprite = wS;
        }

        if (PlayerProfile.hasBow)
        {
            bow.enabled = true;
        }
        else
        {
            bow.enabled = false;
        }

        if (PlayerProfile.hasLetter)
        {
            letter.enabled = true;
        }
        else
        {
            letter.enabled = false;
        }

        if (PlayerProfile.hasRaft)
        {
            raft.enabled = true;
        }
        else
        {
            raft.enabled = false;
        }
        if (PlayerProfile.hasStepLadder)
        {
            ladder.enabled = true;
        }
        else
        {
            ladder.enabled = false;
        }

        if (PlayerProfile.hasMBook)
        {
            book.enabled = true;
        }
        else
        {
            book.enabled = false;
        }
        if (PlayerProfile.hasBlueRing)
        {
            bRing.enabled = true;
        }
        else
        {
            bRing.enabled = false;
        }
        if (PlayerProfile.hasRedRing)
        {
            rRing.enabled = true;
        }
        else
        {
            rRing.enabled = false;
        }
        if (PlayerProfile.hasPowerBracelet)
        {
            bracelet.enabled = true;
        }
        else
        {
            bracelet.enabled = false;
        }

        tri.text = PlayerProfile.triforce.ToString();

        
        if(tS==true)
        {
            stopTime -= Time.deltaTime;

            if (stopTime <= 0)
            {
                tS = false;
                stopTime = 3;
            }
        }

        int j = UnityEngine.Random.Range(0, 281);
        int k = UnityEngine.Random.Range(0,50);
        int h = UnityEngine.Random.Range(0, 45);
        int a = UnityEngine.Random.Range(0, 38);
        if (stopT ==  true)
        {
            fr -= Time.deltaTime;
            

            eneMies[j].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            eneMies[j].GetComponent<Octorock>().enabled = false;
            spi[k].GetComponent<Rigidbody2D>().constraints  = RigidbodyConstraints2D.FreezeAll;
            spi[k].GetComponent<Spider>().enabled = false;
            fly[h].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            fly[h].GetComponent<Fly>().enabled = false;
            slime[a].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            slime[a].GetComponent<Slime>().enabled = false;

            
            
        }
        if(stopT == false)
        {
            eneMies[j].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            eneMies[j].GetComponent<Octorock>().enabled = true;
            spi[k].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            spi[k].GetComponent<Spider>().enabled = true;
            fly[h].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            fly[h].GetComponent<Fly>().enabled = true;
            slime[a].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            slime[a].GetComponent<Slime>().enabled = true;
        }

        itemTime -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.X))
        {
            if (ItemManager.bombActive && PlayerProfile.bombs > 0 && itemTime <= 0)
            {
                Instantiate(bomb, attPoint.position, attPoint.rotation);
                PlayerProfile.bombs--;
                itemTime = 2f;
            }
        }

        if (fr <= 0)
        {

            stopT = false;
            fr = 3;
        }




    }

    private void FixedUpdate()
    {
        if(kbCounter <=0)
        {
            rb.velocity = new Vector2(mov.x * speed, mov.y * speed);
        }
        else
        {
            if(knockRight==true)
            {
                rb.velocity = new Vector2(-kbForce, 0);
               
            }
            if (knockRight==false)
            {
                rb.velocity = new Vector2(kbForce, 0);
            }

           

            kbCounter -= Time.deltaTime;
        }
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("HC"))
        {

            maxHealth += 1;

            health = maxHealth;

            Destroy(other.gameObject);
            
        }

        if(other.gameObject.CompareTag("Rupee"))
        {
            PlayerProfile.rupees += 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Bomb"))
        {
            PlayerProfile.bombs += 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Heart"))
        {
            health += 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Fairy"))
        {
            health = maxHealth;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Clock"))
        {

            stopT = true;
            Destroy(other.gameObject);
           
        }

        if(other.gameObject.CompareTag("Rock"))
        {
            TakeDamage(1);
        }

        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Rock") || other.gameObject.CompareTag("Statue") || other.gameObject.CompareTag("Projectile"))
        {

           /* Vector2 dire = (col.transform.position - transform.position).normalized;

            Vector2 knockBack = dire * kbForce;

            rb.AddForce(knockBack, ForceMode2D.Impulse);*/

            kbCounter = kbTotal;

            if (other.transform.position.x <= transform.position.x)
            {
                knockRight = false;
            }

            if (other.transform.position.x > transform.position.x)
            {
                knockRight = true;
            }

           

        }
    }

    private void Attack()
    {
        Collider2D[] hitE = Physics2D.OverlapCircleAll(attPoint.position, attRange, enemies);

        foreach(Collider2D enemy in hitE)
        {
            enemy.GetComponent<EnemyHP>().hp -= att;

        }


        if(health == maxHealth )
        {

           
            var bullet = Instantiate(swordShoot, attPoint.position, attPoint.rotation).GetComponent<SWPR>();

           

            bullet.Dir = this.dir;

            
        }
    }

    public  static void TakeDamage(float damage)
    {
        health -= damage;
       
    }



    
    

}
