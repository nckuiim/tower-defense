using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���O

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

    //���ʭ^��z�b�A�קK�b�즲�L�{���P��L����I��
    void OnMouseDown()
    {
        d = true;
        gameObject.transform.Translate(0, 0, 100);
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }



    //���^�������H�۹��в���
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

    //��z�b���ʦ^�쥻���a��
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
