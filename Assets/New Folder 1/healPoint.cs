using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class healPoint : MonoBehaviour
{
    public float cureAmount = 10;
    public static bool onTheBuffSpot = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetMouseButton(0))

            {
                gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
                //gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            }
        
    }
    
    
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.tag == "tower1")
        {
            onTheBuffSpot = true;
            Debug.Log("Buff tower1.");
            
            HPofTower1.hp += cureAmount;
            //GameObject.Find("HPofTower1").GetComponent<HPofTower1>().HPChange();
            GameObject.Find("HPofTower1").SendMessage("HPChange");
            //HPofTower1.HPChange();
        }
        else if(other.gameObject.tag == "tower2")
        {
            Debug.Log("Buff tower2.");
        }
    }
    
}

