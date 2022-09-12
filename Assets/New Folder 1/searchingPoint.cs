using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class searchingPoint : MonoBehaviour
{
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

        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "soldier1")
        {
            GameObject.Find("DataBar").SendMessage("showSoldier1Data");
        }
        else if (other.gameObject.tag == "QQMan")
        {
            GameObject.Find("DataBar").SendMessage("showQQManData");
        }

    }
}
