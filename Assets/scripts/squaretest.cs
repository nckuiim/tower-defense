using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squaretest : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float moveSpeed = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
