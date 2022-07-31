using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HoleManager : MonoBehaviour
{
    [SerializeField] public GameObject[] holeNum; //存放各個hole的game object array
    [SerializeField] bool[] hasTower; //存放是否可放置的bool array
    public float[] distance = new float[15]; //存放tower和hole距離的array
    GameObject placeHole; //和tower為最短距離且可放置的hole

    public float calculateMin(Vector2 towerPos) //計算距離，parameter為滑鼠放開時的tower位置
    {
        float min; //最小距離
        for(int i = 0; i < holeNum.Length; i++) //計算距離
        {
            distance[i] = Vector2.Distance(towerPos, holeNum[i].transform.position);
        }
        min = minDistance();
        return min; //回傳最小距離給tower，讓其根據最小距離判斷是否可放置
    }

    public float minDistance() //找到distance中的最小值
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

    public bool whetherPlace(float minDistance) //判斷該位置是否可放
    {
        if(minDistance > 1.5) //最小距離離所有hole太遠，return false
        {
            return false;
        }
        else //和某個hole較近
        {
            int index = Array.IndexOf(distance,minDistance); //得到hole的index
            if(hasTower[index] == false) //若該位置沒有放置tower，return true
            {
                hasTower[index] = true; //將hole設為有放置tower
                placeHole = holeNum[index]; //找出該hole的gmae object
                return true;
            }
            else //若該位置有放置tower，return false
            {
                return false;
            }
            
        }
    }

    public GameObject getHole() //回傳hole game object給tower 
    {
        return placeHole;
    }

    public bool checkPos(Vector2 towePos) //確認tower是否和hole在同一位置上
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
