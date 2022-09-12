using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class burnPoint : MonoBehaviour
{
    public float burnDamage = 10;
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

    /*public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "soldier1")
        {
            
            GameObject mCanvas;
            
            mCanvas = GameObject.FindGameObjectWithTag("mCanvas");
            Debug.Log("Burning soldier1.");

            for (int i = 0; i < mCanvas.transform.childCount; i++)
            {
                
                GameObject child = mCanvas.transform.GetChild(i).gameObject;
                
                if (i == 5)
                    child.SendMessage("HPChangeS");
            }

            
    
        }
        
        
        
        
        /*else if (other.gameObject.tag == "tower1")
        {
            Debug.Log("Burning tower1.");
            HPofTower1.hp -= burnDamage;
            GameObject.Find("HPofTower1").SendMessage("HPChange");
        }*/

    //}

}
