using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
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

    public BoxCollider2D bx;

    public LayerMask sword;
    public LayerMask fly;

    // Start is called before the first frame update
    void Start()
    {
        SetNewDestination();
    }

    // Update is called once per frame
    void Update()
    {




        transform.position = Vector3.MoveTowards(transform.position, wP, speed * Time.deltaTime);


        if (transform.position == wP)
        {
            enabled = true;
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                initT = 2;

                enabled = false;

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

        if(enabled)
        {
            Physics2D.IgnoreLayerCollision(12, 15, false);
        }
        if (enabled == false)
        {
            Physics2D.IgnoreLayerCollision(12, 15, true);
        }

    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(mov.x * speed, mov.y * speed);
        Vector3 temp = Vector3.MoveTowards(transform.position, wP, speed * Time.deltaTime);


        //spawner.transform.rotation = Quaternion.Euler(0, 0, 0);

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        

        if (other.gameObject.CompareTag("Link"))
        {
            PlayerMovement.TakeDamage(0.5f);
        }


    }


    void SetNewDestination()
    {
        wP = new Vector2(Random.Range(minDistanceX, maxDistanceX), Random.Range(minDistanceY, maxDistanceY));


    }


  
}
