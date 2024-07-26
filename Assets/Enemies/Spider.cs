using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public float speed;

    public float maxDistanceX;
    public float minDistanceX;
    public float maxDistanceY;
    public float minDistanceY;

    public float timer;

    public float initT;

    public Vector3 wP;

    public PlayerMovement link;


    private void Start()
    {


        SetNewDestination();

    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wP, speed * Time.deltaTime);

        if (transform.position == wP)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                SetNewDestination();

                timer = initT;
            }

        }

      



    }

    void SetNewDestination()
    {
        wP = new Vector2(Random.Range(minDistanceX, maxDistanceX), Random.Range(minDistanceY, maxDistanceY));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       

        if (other.gameObject.CompareTag("Link"))
        {
            PlayerMovement.TakeDamage(1f);
        }

       
    }

  
}
