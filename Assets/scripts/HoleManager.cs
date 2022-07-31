using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HoleManager : MonoBehaviour
{
    [SerializeField] public GameObject[] holeNum; //�s��U��hole��game object array
    [SerializeField] bool[] hasTower; //�s��O�_�i��m��bool array
    public float[] distance = new float[15]; //�s��tower�Mhole�Z����array
    GameObject placeHole; //�Mtower���̵u�Z���B�i��m��hole

    public float calculateMin(Vector2 towerPos) //�p��Z���Aparameter���ƹ���}�ɪ�tower��m
    {
        float min; //�̤p�Z��
        for(int i = 0; i < holeNum.Length; i++) //�p��Z��
        {
            distance[i] = Vector2.Distance(towerPos, holeNum[i].transform.position);
        }
        min = minDistance();
        return min; //�^�ǳ̤p�Z����tower�A����ھڳ̤p�Z���P�_�O�_�i��m
    }

    public float minDistance() //���distance�����̤p��
    {
        float min;
        min = distance[0];
        for (int i = 1; i < holeNum.Length; i++)
        {
            if (distance[i] < min)
            {
                min = distance[i];
            }
        }
        return min;
    }

    public bool whetherPlace(float minDistance) //�P�_�Ӧ�m�O�_�i��
    {
        if(minDistance > 1.5) //�̤p�Z�����Ҧ�hole�ӻ��Areturn false
        {
            return false;
        }
        else //�M�Y��hole����
        {
            int index = Array.IndexOf(distance,minDistance); //�o��hole��index
            if(hasTower[index] == false) //�Y�Ӧ�m�S����mtower�Areturn true
            {
                hasTower[index] = true; //�Nhole�]������mtower
                placeHole = holeNum[index]; //��X��hole��gmae object
                return true;
            }
            else //�Y�Ӧ�m����mtower�Areturn false
            {
                return false;
            }
            
        }
    }

    public GameObject getHole() //�^��hole game object��tower 
    {
        return placeHole;
    }

    public bool checkPos(Vector2 towePos) //�T�{tower�O�_�Mhole�b�P�@��m�W
    {
        for(int i = 0; i < holeNum.Length; i++)
        {
            if(towePos == (Vector2)holeNum[i].transform.position)
            {
                return true;
            }
        }

        return false;
    }
}
