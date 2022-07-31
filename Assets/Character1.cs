using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float moveSpeed = 75f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad6))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        else if(Input.GetKey(KeyCode.Keypad4))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.Keypad8))
        {
            transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.Keypad5))
        {
            transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
        }
    }
}
