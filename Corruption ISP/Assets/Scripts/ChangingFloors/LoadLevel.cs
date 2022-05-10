using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //getting the Scene managment system from unity

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
        Handler = GameObject.FindWithTag("Level Handler");
        DontDestroyOnLoad(player); //carries over these objects to the next level
        DontDestroyOnLoad(Handler);
        DontDestroyOnLoad(Camera.main);
    }

    void OnTriggerEnter2D(Collider2D hitinfo) //detects collison with the door to the next level
    {
        GameObject hitinfoGameObject = hitinfo.gameObject;

        if (hitinfoGameObject.name == "Player") //ensures the plater colided with the door 
        {
            LoadScene();
        }
    }

    void LoadScene() //loads the specific scene
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
