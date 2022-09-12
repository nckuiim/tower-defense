using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootPoint : MonoBehaviour
{
    public static bool onTheShootSpot = false;
    public float shootDamage = 25;
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

        if (other.gameObject.tag == "soldier1")
        {
            HPofSoldier1.hpS -= shootDamage;
            ShootingDamage.theDamage = -shootDamage;
            onTheShootSpot = true;
            
            
            //GameObject GO;
            //GO = GameObject.Find("HPofSoldier1");
            //if (GO == null)
            //{
            //GO.GetComponent<HPofSoldier1>().HPChangeS();
            //Debug.Log("GO is null.");
            //}
            //GameObject.Find("HPofSoldier1").SendMessage("HPChangeS");
            //GameObject.Find("HPofSoldier1").GetComponent<HPofSoldier1>().HPChangeS();

            //HPofTower1.HPChange();
            GameObject mCanvas;

            mCanvas = GameObject.FindGameObjectWithTag("mCanvas");
            Debug.Log("shooting soldier1.");

            for (int i = 0; i < mCanvas.transform.childCount; i++)
            {
                //Debug.Log(i);
                GameObject child = mCanvas.transform.GetChild(i).gameObject;
                //Debug.Log(child.name);
                /*if (child.name == "HPofSoldier1")
                {
                    Debug.Log("Find child.");
                    child.SendMessage("HPChangeS");

                    break;
                }*/
                if (i == 5)
                    child.SendMessage("HPChangeS");
                if (i == 6)
                    child.SendMessage("DamageChange");
            }

        }
        /*else if (other.gameObject.tag == "tower1")
        {
            Debug.Log("Burning tower1.");
            HPofTower1.hp -= burnDamage;
            GameObject.Find("HPofTower1").SendMessage("HPChange");
        }*/

    }
}
