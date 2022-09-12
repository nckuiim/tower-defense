using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//詠吏

public class heroDrag : MonoBehaviour
{
    private float xPos;
    private float yPos;
    private float zPos = 0;
    private Vector3 screenPoint;
    private Vector3 offset;
    bool d = false;

    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;

    void Start()
    {
        // Animator
        myAnimator = gameObject.transform.Find("Sprite").GetComponent<Animator>();
        mySpriteRenderer = gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>();
        mySpriteRenderer.flipX = true;
    }

    //移動英雄z軸，避免在拖曳過程中與其他物件碰撞
    void OnMouseDown()
    {
        d = true;
        gameObject.transform.Translate(0, 0, 100);
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }



    //讓英雄移動隨著鼠標移動
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        if (xPos > curPosition.x)
        {
            mySpriteRenderer.flipX = true;
        }
        else if (xPos < curPosition.x)
        {
            mySpriteRenderer.flipX = false;
        }
        xPos = curPosition.x;
        yPos = curPosition.y;
        transform.position = curPosition;
        myAnimator.SetInteger("Status", 1);
    }

    //把z軸移動回原本的地方
    private void OnMouseUp()
    {
        Vector3 vector = new Vector3(xPos, yPos, zPos);
        transform.position = vector;
        d = false;
    }

    void FixedUpdate()
    {
        // Movement
        if (d)
        {
            myAnimator.SetInteger("Status", 1);
        }
        else
        {
            myAnimator.SetInteger("Status", 0);
        }
    }
}
