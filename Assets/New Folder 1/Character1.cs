using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Character1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float moveSpeed = 75f;
    public static string enemytitle = "Black Knight";
    public static float basicHP = 100;
    public static float basicATK = 10;
    public static float basicATKSpeed = 5;
    
    [SerializeField] public static string basicData = "EnemyTitle : Black Knight\n" +
        "basicHP : 100\nbasicATK : 10\nbasicATKSpeed : 5";
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
