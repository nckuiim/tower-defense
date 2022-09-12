using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theFire : MonoBehaviour
{
    public static bool onTheSpot = false;
    public float fireDamage = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) & onTheSpot == false)

        {
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            //gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "soldier1")
        {
            onTheSpot = true;
            
            Invoke("keepBurn", 1.0f);
            Invoke("keepBurn", 2.0f);
            Invoke("keepBurn", 3.0f);
            Invoke("keepBurn", 4.0f);
            Invoke("keepBurn", 5.0f);
            Invoke("keepBurn", 6.0f);
            Invoke("keepBurn", 7.0f);
            Invoke("keepBurn", 8.0f);
            Invoke("keepBurn", 9.0f);
            Invoke("keepBurn", 10.0f);
            Invoke("moveBack", 11.0f);
            

            //}


        }
        //gameObject.transform.Translate(120f, -558f, 0);
    }

    public void keepBurn()
    {
        //for (int j = 0; j < 10; j++)
        //{
            //yield return new WaitForSeconds(1);
            
        HPofSoldier1.hpS -= fireDamage;
        ShootingDamage.theDamage = -fireDamage;

        GameObject mCanvas;

            mCanvas = GameObject.FindGameObjectWithTag("mCanvas");
            //Debug.Log("Burning soldier1.");

            for (int i = 0; i < mCanvas.transform.childCount; i++)
            {

                GameObject child = mCanvas.transform.GetChild(i).gameObject;

                if (i == 5)
                    child.SendMessage("HPChangeS");
                if (i == 6)
                    child.SendMessage("DamageChange");
        }
        //}
    }
    public void moveBack()
    {
        gameObject.transform.Translate(110f, -900f, 0);
        onTheSpot = false;
    }
}
