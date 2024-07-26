using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoLevel : MonoBehaviour
{
    public int ind;
    public Vector2 linkPos;
    public VectorValue linkStorage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoScene()
    {
        SceneManager.LoadScene(ind);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.tag  == "Link")
        {
            linkStorage.initValue = linkPos;
            GoScene();
        }
    }
}
