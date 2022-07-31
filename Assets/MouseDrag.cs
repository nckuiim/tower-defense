using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private Vector3 dragoffset;
    private Vector3 original;
    private Vector3 hole;
    

    public void Start()
    {
       // hole = GameObject.Find("Hole").transform.position;
        //Debug.Log(hole);
    }
    public void Awake()
    {
        original = transform.position;
    }
    public void OnMouseDown()
    {
        
        dragoffset = transform.position - getMousePos();
    }

    public void OnMouseDrag()
    {
        transform.position = getMousePos() + dragoffset;
    }

    public void OnMouseUp()
    {
        //transform.position = original;
        //Debug.Log(_hole.transform.position);
       /* hole = GameObject.Find("Hole").transform.position;
        if (Vector2.Distance(transform.position,hole) < 3)
        {
            transform.position = hole;
        }*/
    }

    Vector3 getMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    
}
