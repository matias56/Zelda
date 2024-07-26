using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    private TimeManager timemanager;
    private Rigidbody2D rb;
    private bool IsStopped;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timemanager.TimeIsStopped && !IsStopped)
        {
            
                

               
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                IsStopped = true; // prevents this from looping
            
        }
    }

    public void ContinueTime()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        IsStopped = false;
        
    }
}
