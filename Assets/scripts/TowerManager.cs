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

    public void spawnTower(int i , int coin)
    {
        tower = Instantiate(TowerType[i - 1], transform); //�ͦ��Utype of tower
        tower.name = "tower" + i + "Base"; //����object name , make it not be cloned
        Color co = tower.GetComponent<SpriteRenderer>().color;
        switch (i) //�ͦ���ҪO���z���סA�Y���������h�D�z���A�������h�z��
        {
            case 1:
                if(coin >= 25)
                {
                    co.a = 1f;
                }
                else
                {
                    co.a = 0.4f;
                }
                break;
            case 2:
                if (coin >= 75)
                {
                    co.a = 1f;
                }
                else
                {
                    co.a = 0.4f;
                }
                break;
            case 3:
                if (coin >= 150)
                {
                    co.a = 1f;
                }
                else
                {
                    co.a = 0.4f;
                }
                break;
            case 4:
                if (coin >= 250)
                {
                    co.a = 1f;
                }
                else
                {
                    co.a = 0.4f;
                }
                break;
            default:
                break;
        }

        tower.GetComponent<SpriteRenderer>().color = co; //�N�z���׳]���z���ΫD�z��

        tower.transform.position = Pos[i-1]; //�ͦ�����m���쥻���U����m
        TowerType[i - 1] = tower; //�N�ͦ���tower��J�s��gmae object��array(prevent destroy finction)
    }

}
