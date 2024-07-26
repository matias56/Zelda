using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public Image item;
    public static bool bombActive;
    public Sprite bomb;
    public static bool boomerangActive;
    public Sprite boomerang;

    // Start is called before the first frame update
    void Start()
    {
        bombActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SwitchItem();
        }
    }

    public void SwitchItem()
    {
        if (bombActive == true)
        {
            item.sprite = boomerang;
            bombActive = false;
            boomerangActive = true;
        }
        else if (boomerangActive == true)
        {
            item.sprite = bomb;
            bombActive = true;
            boomerangActive = false;
        }
    }
}
