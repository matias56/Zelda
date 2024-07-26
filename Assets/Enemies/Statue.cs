using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    public float maxDistanceX;
    public float minDistanceX;
    public float maxDistanceY;
    public float minDistanceY;

    public float timer;

    public float initT;

    public Vector3 wP;

    public PlayerMovement link;

    public Vector3 mov;



    public Vector3 scale;

    public Vector3 dir;

    public float ang;
    public float angle;



    public bool isMoving;

    public new bool enabled = true;

    public float enTimer;

    public float enInitT;

    public float disTimer;

    public float disInitT;

    public SpriteRenderer spr;

    public BoxCollider2D bx;

    public LayerMask enem;

    public float aliTimer = 2;

    public bool initiate;

    

    // Start is called before the first frame update
    void Start()
    {
        SetNewDestination();
    }

    // Update is called once per frame
    void Update()
    {



        if(enabled == true)
        {
            this.gameObject.layer = LayerMask.NameToLayer("Enemy"); 

            transform.position = Vector3.MoveTowards(transform.position, wP, speed * Time.deltaTime);

            rb.bodyType = RigidbodyType2D.Dynamic;

            if (transform.position == wP)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    SetNewDestination();

                    timer = initT;
                }

            }






            scale = transform.localScale;



            float angle = Mathf.Atan2(transform.position.x, transform.position.y) * Mathf.Rad2Deg;

            float dirX = dir.x;
            float dirY = dir.y;
            float dirZ = dir.z;

            mov = new Vector3(dirX, dirY, dirZ).normalized;

            dir = wP - transform.position;
            angle = Mathf.Atan2(dirX, dirY) * Mathf.Rad2Deg;
            dir.Normalize();




            mov = new Vector3(dirX, dirY, dirZ).normalized;

            mov = dir;
            mov = new Vector2(dirX, dirY);



        }

        if (initiate == true)
        {
            StartCoroutine(Alive());
        }




    }

    private void FixedUpdate()
    {

        if(enabled == true)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, wP, speed * Time.deltaTime);
        }
        //rb.velocity = new Vector2(mov.x * speed, mov.y * speed);
       


        //spawner.transform.rotation = Quaternion.Euler(0, 0, 0);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacles"))
        {


            SetNewDestination();
        }


        if (other.gameObject.CompareTag("Link"))
        {
            initiate = true;

            if(enabled==true)
            {
                PlayerMovement.TakeDamage(1f);
            }
        }


    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {


            SetNewDestination();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {


            SetNewDestination();
        }
    }

    void SetNewDestination()
    {
        wP = new Vector2(Random.Range(minDistanceX, maxDistanceX), Random.Range(minDistanceY, maxDistanceY));


    }

    public IEnumerator Alive()
    {


        aliTimer -= Time.deltaTime;

        if(aliTimer <= 0)
        {
            enabled = true;

            yield return null;
        }

        
    }
}
