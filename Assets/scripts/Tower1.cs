using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tower1 : MonoBehaviour
{
    private Vector2 offset; //�p��ƹ��M����Z���t�Z
    TowerManager temp; //�ΨөI�sTowerManager function
    HoleManager temp2; //�ΨөI�sHoleManager function
    GameObject hole; //tower�n��hole��m

    Vector2 getMousePos() //get mouse position function
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }

    public void OnMouseDown() //�I���ƹ��ɩI�s��function
    {
        temp2 = GameObject.Find("HoleManager").GetComponent<HoleManager>();
        bool theSame = temp2.checkPos(transform.position);

        if (theSame) //�Y�b�P��m�hdo nothing
        {
        }
        else
        {
            offset = (Vector2)transform.position - getMousePos();

            Color co = gameObject.GetComponent<SpriteRenderer>().color;//���ܳz����
            co.a = 0.5f;
            gameObject.GetComponent<SpriteRenderer>().color = co;

            temp = GetComponentInParent<TowerManager>();

            string name = gameObject.name;
            switch (name)
            {
                case "tower1":
                    temp.spawnTower(1);
                    break;
                case "tower2":
                    temp.spawnTower(2);
                    break;
                case "tower3":
                    temp.spawnTower(3);
                    break;
                case "tower4":
                    temp.spawnTower(4);
                    break;
                case "tower5":
                    temp.spawnTower(5);
                    break;
                default:
                    Debug.Log("tower not exist");
                    break;
            }
        }
    }

    public void OnMouseDrag() //�즲�ƹ��ɩI�s��function
    {
        temp2 = GameObject.Find("HoleManager").GetComponent<HoleManager>();
        bool theSame = temp2.checkPos(transform.position);
        if (theSame) //�Y�b�P��m�hdo nothing
        {
        }
        else
        {
            transform.position = getMousePos() + offset; //�����m����
        }
    }

    public void OnMouseUp() //�ƹ���}�ɩI�s��function
    {
        temp2 = GameObject.Find("HoleManager").GetComponent<HoleManager>();
        bool theSame = temp2.checkPos(transform.position);
        if (theSame) //�Y�b�P��m�hdo nothing
        {
        }
        else
        {
            float minDistance; //tower�M�Ҧ�hole���̤p�Z��
            bool place; //�P�_�Ӧ�m�O�_�i��mtower
            temp2 = GameObject.Find("HoleManager").GetComponent<HoleManager>();
            minDistance = temp2.calculateMin(transform.position); //�p��ثetower��m�M�Ҧ�hole���Z��
            place = temp2.whetherPlace(minDistance); //�ھڳ̤p�Z����bool�M�w�O�_�i��m

            if (place == false)
            {
                Destroy(gameObject); //�Y����hdestroy gameobject
            }
            else
            {
                hole = temp2.getHole(); //�Y�i�H���o�̤p�Z����hole����
                transform.position = hole.transform.position; //�Ntower����m�אּhole����m

                Color co = gameObject.GetComponent<SpriteRenderer>().color;//��m������N�z���׽զ^���`
                co.a = 1f;
                gameObject.GetComponent<SpriteRenderer>().color = co;
            }
        }
       
    }

}
