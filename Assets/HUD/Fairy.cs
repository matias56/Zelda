using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    public PlayerMovement link;
    public float speed;
    private float distance;
    public float dB;
    // Start is called before the first frame update
    void Start()
    {
        link = GameObject.FindGameObjectWithTag("Link").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, link.transform.position);
        Vector2 dir = link.transform.position - transform.position;

        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if(distance  < dB)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, link.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }
}
