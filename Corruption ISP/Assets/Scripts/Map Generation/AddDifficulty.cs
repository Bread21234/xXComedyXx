using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDifficulty : MonoBehaviour
{
    private NextLevel Level;
    // Start is called before the first frame update
    void Start()
    {
        Level = GameObject.FindGameObjectWithTag("Level Handler").GetComponent<NextLevel>();
        Level.enemySpawners.Add(this.gameObject);
    }

}
