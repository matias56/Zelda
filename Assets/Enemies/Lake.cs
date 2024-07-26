using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lake : MonoBehaviour
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

    public GameObject bullet;

    public Transform spawner;

    public float shootTime;

    public float bSpeed = 10;

    public float shootTimeInit = 3;

    private Vector3 shootDirection;

    public Transform player;

    public float lineSite;

    public bool enemySighted;

    // Start is called before the first frame update
    void Start()
    {
        SetNewDestination();
    }

    // Update is called once per frame
    void Update()
    {




        transform.position = Vector3.MoveTowards(transform.position, wP, speed * Time.deltaTime);
        float distFromPlayer = Vector2.Distance(player.position, transform.position);

        if (transform.position == wP)
        {
            timer -= Time.deltaTime;

            enabled = true;

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


        if (enabled)
        {




        
                ToggleEnable();

           
        }

        if (!enabled)
        {


                ToggleDisable();
             
        }

        player = GameObject.FindWithTag("Link").transform;

        shootTime -= Time.deltaTime;




        if (distFromPlayer <= lineSite)
        {
            enemySighted = true;
        }

        //spawner.transform.rotation = Quaternion.Euler(0, 0, dir.z);

        //b.rb.velocity = this.dir;


        if(enemySighted == true)
        {
            CheckShoot();
        }
        
    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(mov.x * speed, mov.y * speed);
        Vector3 temp = Vector3.MoveTowards(transform.position, wP, speed * Time.deltaTime);


        //spawner.transform.rotation = Quaternion.Euler(0, 0, 0);

    }

    
    void SetNewDestination()
    {
        wP = new Vector2(Random.Range(minDistanceX, maxDistanceX), Random.Range(minDistanceY, maxDistanceY));


    }


    void ToggleDisable()
    {
        enabled = false;


        spr.enabled = false;

        bx.enabled = false;

    }

    void ToggleEnable()
    {
        enabled = true;


        spr.enabled = true;

        bx.enabled = true;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineSite);

    }

    private void CheckShoot()
    {
        if (shootTime <= 0)
        {
            shootDirection = (wP - transform.position).normalized;

            float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;

            if (angle < 45 && angle > -45) // Right
            {
                Shoot(Vector2.right);
            }
            else if (angle >= 45 && angle <= 135) // Up
            {
                Shoot(Vector2.up);
            }
            else if (angle > 135 || angle < -135) // Left
            {
                Shoot(Vector2.left);
            }
            else // Down
            {
                Shoot(Vector2.down);
            }

            shootTime = shootTimeInit;
        }
    }

    public void Shoot(Vector2 dir)
    {
        dir = link.transform.position - transform.position;

        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;



        shootTimeInit = Random.Range(4, 8);


        GameObject rock = Instantiate(bullet, spawner.position, Quaternion.identity);
        rock.GetComponent<Rigidbody2D>().velocity = dir * bSpeed;


        rock.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        rock.transform.rotation = Quaternion.Euler(Vector3.forward * angle);




    }
}
