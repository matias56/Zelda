using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rock;
    public float timer;
    public float initTimer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(2, 8);

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(rock, this.transform.position, this.transform.rotation);

            initTimer = Random.Range(2, 8);

            timer = initTimer;

        }
    }
}
