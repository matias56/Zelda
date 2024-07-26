using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDisplay : Interactable
{


    public Sword key;

   
    // Start is called before the first frame update
    void Start()
    {
        key.isKey = true;
        
      

       
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTaken==true)
        {
            PlayerProfile.hasSword = true;
        }
        if (PlayerProfile.hasSword == true)
        {
            Destroy(this.gameObject);
        }
    }

    


}
