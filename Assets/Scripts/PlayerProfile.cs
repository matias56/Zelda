using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerProfile : MonoBehaviour
{
    public static string playerName;
    public static int rupees;
    public static bool hasClock;
    public static bool hasPotion;
    public static bool has2ndPotion;
    public static bool hasLetter;
    public static bool hasFood;
    public static bool hasSword;
    public static bool hasWSword;
    public static bool hasMSword;
    public static bool hasMShield;
    public static bool hasBoomerang;
    public static bool hasMBoomerang;
    public static int bombs;
    public static bool hasBow;
    public static int arrows;
    public static int silverArrows;
    public static bool hasBlueCandle;
    public static bool hasRedCandle;
    public static bool hasBlueRing;
    public static bool hasRedRing;
    public static bool hasPowerBracelet;
    public static bool hasRecorder;
    public static bool hasRaft;
    public static bool hasStepLadder;
    public static bool hasMRod;
    public static bool hasMBook;
    public static int keys;
    public static int mKeys;
    public static bool hasMap;
    public static bool hasCompass;
    public static int triforce;

    


    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);

      

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
