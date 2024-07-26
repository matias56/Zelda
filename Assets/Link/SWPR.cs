using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWPR : MonoBehaviour
{
    public float Sspeed = 10f;
    
   
    public Rigidbody2D rb;

    public Vector2 Dir { get; set; }

    public float timer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        

        timer -= Time.deltaTime;

        rb.velocity = Dir;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        this.GetComponent<Rigidbody2D>().velocity = transform.up * Sspeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       
        
       
        Destroy(gameObject);
    }

    public void Setup(Vector2 vel, Vector3 dir)
    {
        rb.velocity = vel.normalized * Sspeed;
        transform.rotation = Quaternion.Euler(dir);
    }

  
}
