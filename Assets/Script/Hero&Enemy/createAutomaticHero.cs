using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���O

public class createAutomaticHero : MonoBehaviour
{

    public GameObject Prefab;
    public GameObject[] waypoints;
    int ctr = 0;
    private void OnMouseDown()
    {
        //�ͦ��^��
        GameObject newEnemy = (GameObject)
            Instantiate(Prefab);
        //�����^�����ʸ��u
        newEnemy.GetComponent<MoveEnemy>().waypoints = waypoints;
        //�վ�W�r(�קK�ۦP�W�r�y���԰�bug)
        newEnemy.name = newEnemy.name + ctr;
        ctr++;
    }
}
