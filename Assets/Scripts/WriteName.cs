using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WriteName : MonoBehaviour
{
    public GameObject nameP;
    public GameObject inpDis;
    public static string player;
    public GameObject save;
    public GameObject cont;
    public GameObject erase;
    // Start is called before the first frame update
    void Start()
    {
        save.SetActive(true);
        cont.SetActive(false);
        erase.SetActive(false);
    }

    // Update is called once per frame
    public void StoreName()
    {
        player = nameP.GetComponent<Text>().text;
        inpDis.GetComponent<Text>().text = player;
        save.SetActive(false);
        cont.SetActive(true);
        erase.SetActive(true);
        PlayerProfile.playerName = player;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Overworld");
    }

    public void EraseGame()
    {
        player = null;

        save.SetActive(true);
        cont.SetActive(false);
        erase.SetActive(false);
    }
}
