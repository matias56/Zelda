using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public PlayerMovement link;

    public Vector2 Dir { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
      
       
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Dir;

       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Link"))
        {
            PlayerMovement.TakeDamage(1f);
        }

        Destroy(gameObject);

        if(other.gameObject.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }
      
    }

    private void FixedUpdate()
    {
        //this.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }

    public void Setup(Vector2 vel, Vector3 dir)
    {
        rb.velocity = vel.normalized * speed;
        transform.rotation = Quaternion.Euler(dir);
    }
}
