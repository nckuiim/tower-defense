using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] GameObject[] TowerType; //�s��U������tower ��game object array
    GameObject tower; //�����ͦ���tower
    Vector3[] Pos = new Vector3[15]; //�����̩��U����tower����m���y��array

    void Start() //�}�l�ɥ��N���U�y�Цs�JPos
    {
        for (int i = 0; i < TowerType.Length; i++)
        {
            Pos[i] = TowerType[i].transform.position;
        }
    }

    public void spawnTower(int i)
    {
        tower = Instantiate(TowerType[i - 1], transform); //�ͦ��Utype of tower
        tower.name = "tower" + i; //����object name , make it not be cloned

        Color co = tower.GetComponent<SpriteRenderer>().color; //�N�ͦ����z���קאּ���`
        co.a = 1f;
        tower.GetComponent<SpriteRenderer>().color = co;

        tower.transform.position = Pos[i-1]; //�ͦ�����m���쥻���U����m
        TowerType[i - 1] = tower; //�N�ͦ���tower��J�s��gmae object��array(prevent destroy finction)
    }

}
