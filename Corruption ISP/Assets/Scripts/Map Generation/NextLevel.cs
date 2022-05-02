using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{

   // public GameObject[] enemySpawners;
    public List<GameObject> enemySpawners;
    public int level = 0;

    // Start is called before the first frame update
    void Start() //make run every time a new scene is loaded
    {
      //  StartCoroutine(holdPlease());
        
    }
    public IEnumerator holdPlease() //activates on every room
    {
        yield return new WaitForSeconds(1f);
        foreach(GameObject specific in enemySpawners)
        {
            if(specific != null){
                EnemySpawner classSpawner = specific.GetComponent<EnemySpawner>();
               // Debug.Log(classSpawner);
                if(classSpawner != null)
                {
                    classSpawner.addEnemies(level);
                }
            }
        }
    }
    public void levelUp(){
        level += 1;
    }
}
