using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octorock : MonoBehaviour
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

    public Animator anim;

    public float lineSite;

    

    public GameObject bullet;

    public Transform spawner;

    public Transform player;

    public bool enemySighted;

    public float shootTime;

    public float bSpeed = 10;

    public PlayerMovement link;

    public Vector3 mov;

    public float shootTimeInit = 3;

    public Vector3 scale;
    
    public Vector3 dir;

    public float ang;
    public float angle;

    public Bullet b;

    public bool isMoving;

    private Vector3 shootDirection;

   



    private void Start()
    {
       

        SetNewDestination();

    }

    private void Update()
    {
       
    

        transform.position = Vector3.MoveTowards(transform.position, wP, speed * Time.deltaTime);
        float distFromPlayer = Vector2.Distance(player.position, transform.position);

        if (transform.position == wP)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                SetNewDestination();

                timer = initT;
            }

        }


        player = GameObject.FindWithTag("Link").transform;
       
        

        scale = transform.localScale;



        float angle = Mathf.Atan2(transform.position.x, transform.position.y) * Mathf.Rad2Deg;

        float dirX = dir.x;
        float dirY = dir.y;
        float dirZ = dir.z;

        mov = new Vector3(dirX, dirY, dirZ).normalized;

        dir = wP -  transform.position;
        angle = Mathf.Atan2(dirX, dirY) * Mathf.Rad2Deg;
        dir.Normalize();


        anim.SetFloat("MoveX", dirX);
        anim.SetFloat("MoveY", dirY);

        mov = new Vector3(dirX, dirY, dirZ).normalized;

        mov = dir;
        mov = new Vector2(dirX, dirY);

        /*if (dirX == 1 || dirX == -1 || dirY == 1 || dirY == -1)
        {
            
            spawner.position = transform.position + mov.normalized;
            spawner.rotation = this.transform.rotation;
           

        }*/

        if (distFromPlayer <= lineSite)
        {
            enemySighted = true;
        }


        shootTime -= Time.deltaTime;

       




        //spawner.transform.rotation = Quaternion.Euler(0, 0, dir.z);

        //b.rb.velocity = this.dir;

        CheckShoot();
    }


    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(mov.x * speed, mov.y * speed);
        Vector3 temp = Vector3.MoveTowards(transform.position, wP, speed * Time.deltaTime);
        spawner.position = transform.position + mov.normalized;

        //spawner.transform.rotation = Quaternion.Euler(0, 0, 0);

    }

    void SetNewDestination()
    {
        wP = new Vector2(Random.Range(minDistanceX, maxDistanceX), Random.Range(minDistanceY, maxDistanceY));

       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacles"))
        {


            SetNewDestination();
        }


        if (other.gameObject.CompareTag("Link"))
        {
            PlayerMovement.TakeDamage(0.5f);
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


        shootTimeInit = Random.Range(4, 8);


        GameObject rock = Instantiate(bullet, spawner.position, Quaternion.identity);
        rock.GetComponent<Rigidbody2D>().velocity = dir * bSpeed;

        if(dir == Vector2.right)
        {
            rock.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if(dir == Vector2.left)
        {
            rock.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if(dir == Vector2.up)
        {
            rock.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (dir == Vector2.down)
        {
            rock.transform.rotation = Quaternion.Euler(0, 0, 180);
        }




    }

    

}
