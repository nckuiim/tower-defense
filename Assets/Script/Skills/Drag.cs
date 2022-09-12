using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public bool isDragging;
    public bool isMoved = false;
    public float x;
    public float y;

    public void OnMouseDown()
    {
        isDragging = true;
    }
    public void OnMouseUp()
    {
        isDragging = false;
    }
    void Update()
    {
        if (isDragging == true && isMoved == false)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
            
        }
        for (int i = -6; i <= 6; i++)
        {
            for (int j = -2; j <= 3; j++)
            {
                if (isDragging == false && isMoved == false && transform.position.x >= (float)i - 0.5f && transform.position.x <= (float)i + 0.5f && transform.position.y >= (float)j - 0.5f && transform.position.y <= (float)j + 0.5f)
                {
                    transform.position = new Vector2(i, j);
                    isMoved = true;
                }
                else if (isDragging == false && (transform.position.x >= 6.5f || transform.position.x <= -6.5f) || (transform.position.y >= 3.5f || transform.position.y <= -2.5f) && transform.position.x != -6 && transform.position.y != -4)
                {
                    transform.position = new Vector2(x, y);
                }
            }
        }

    }
}
//&& !(((i >= -6 && i <= -2) || (i >= 2 && i <= 6)) && j == 2) && !((i == -2 || i == 2) && (j >= -1 && j <= 1))

/*for(int i = -6; i <= 6;i++)
{
    for (int j = -2; j <= 3; j++)
    {
        if (isDragging == false && transform.position.x >= (float)i - 0.5f && transform.position.x <= (float)i + 0.5f && transform.position.y >= (float)j - 0.5f && transform.position.y <= (float)j + 0.5f)
        {
            transform.position = new Vector2(i, j);
        }
        else if (isDragging == false && transform.position.x >= 7 && transform.position.x <= -7 && transform.position.y >= 4 && transform.position.y <= -3)
        {
            transform.position = new Vector2(-6, -4);
        }
    }
}*/