using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    bool x = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (x)
        {
            Invoke("moved", 140f);
            x = false;
        }
    }

    void moved()
    {
        transform.position = new Vector2(0,0);
        Invoke("moveaway", 3f);

    }

    void moveaway()
    {
        transform.position = new Vector2(-1200, 0);
    }
}

    
