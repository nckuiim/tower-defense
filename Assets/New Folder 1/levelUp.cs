using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) & healPoint.onTheBuffSpot == true)

        {
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            

        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "tower1")
        {
            Invoke("moveBack", 1.5f);

        }

    }

    public void moveBack()
    {
        gameObject.transform.Translate(110f, -900f, 0);
        healPoint.onTheBuffSpot = false;
    }
}
