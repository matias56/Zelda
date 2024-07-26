using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMenu : MonoBehaviour
{
    public Vector3 target;
    public float timer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Profiles");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(transform.position == new Vector3(0f, 0f, -10f))
        {

            timer -= Time.deltaTime;
            
           
        }

        if (timer <= 0)
        {
            GoDown();
        }

       
    }

    private void GoDown()
    {
        
            
            Vector3 tPos = new Vector3(0f, -73f, -10f);
            transform.position = Vector3.Lerp(transform.position, tPos, 0.0001f);
        
       
    }

   
}
