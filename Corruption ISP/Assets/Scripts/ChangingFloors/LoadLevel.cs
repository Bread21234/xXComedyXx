using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public int iLevelToLoad;
    public string sLevelToLoad;

    public bool IntegerToLevel = false; 

    private GameObject player;
    private GameObject Handler;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        DontDestroyOnLoad(player);
        Handler = GameObject.FindWithTag("Level Handler");
        DontDestroyOnLoad(Handler);
        DontDestroyOnLoad(Camera.main);
    }

    void OnTriggerEnter2D(Collider2D hitinfo)
    {
        GameObject hitinfoGameObject = hitinfo.gameObject;

        if (hitinfoGameObject.name == "Player")
        {
            LoadScene();
        }
    }

    void LoadScene()
    {
        if (IntegerToLevel)
        {
            SceneManager.LoadScene(iLevelToLoad);
        }
        else
        {
            SceneManager.LoadScene(sLevelToLoad);
        }
    }
}
