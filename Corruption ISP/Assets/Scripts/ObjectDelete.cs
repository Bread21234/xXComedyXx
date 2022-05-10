using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDelete : MonoBehaviour //this needs to be redone later
{
    public GameObject me;
    int f = 0;
    // Start is called before the first frame update

// Update is called once per frame    
    void FixedUpdate()
    {
        f += 1;
        if (f == 110){
            Destroy(gameObject);
             f = 0;
        }
    }
}
