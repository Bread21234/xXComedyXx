using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void PlayGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void BackToMenu()
    {
        GameObject newGO = new GameObject(); //if let statement??
        if (GameObject.FindWithTag("Player")){
            GameObject player = GameObject.FindWithTag("Player");
            player.transform.parent = newGO.transform;
        }
        if (GameObject.FindWithTag("Level Handler")){
            GameObject Handler = GameObject.FindWithTag("Level Handler");
            Handler.transform.parent = newGO.transform;
        }
        if (GameObject.FindWithTag("MainCamera")){
            GameObject MainCamera = GameObject.FindWithTag("MainCamera");
            MainCamera.transform.parent = newGO.transform;
        }
 //giving all the objects parents so they actually get deleted

        SceneManager.LoadScene(0);
    }
}
