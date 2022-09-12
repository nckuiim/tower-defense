using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class coinUpgrate : MonoBehaviour
{
    public coinCalculation temp1;
    public TextMeshProUGUI showRate;
    private int updateCounter = 0;


    public void useButton()
    {
        Debug.Log("23d");
        int coin;
        int rate;
        int needCoin = 0;
        string nextUpdate = "";
        string nowRate = "";
        bool finishedUpdate = false;
        temp1 = GameObject.Find("CoinNum").GetComponent<coinCalculation>();
        coin = temp1.getCoin();
        rate = temp1.getIncreaseNum();

        switch (updateCounter)
        {
            case 0:
                needCoin = 50;
                rate = 15;
                nextUpdate = "update 100$";
                nowRate = "15$ / second";
                break;
            case 1:
                needCoin = 100;
                rate = 25;
                nextUpdate = "update 150$";
                nowRate = "25$ / second";
                break;
            case 2:
                needCoin = 150;
                rate = 35;
                nextUpdate = "update 200$";
                nowRate = "35$ / second";
                break;
            case 3:
                needCoin = 200;
                rate = 45;
                nextUpdate = "update 250$";
                nowRate = "45$ / second";
                break;
            case 4:
                needCoin = 250;
                rate = 55;
                nextUpdate = "update 300$";
                nowRate = "55$ / second";
                break;
            case 5:
                needCoin = 300;
                rate = 70;
                nextUpdate = "all update done";
                nowRate = "70$ / second";
                finishedUpdate = true;
                break;
            default:
                break;
        }

        if(coin >= needCoin && !finishedUpdate)
        {
            temp1.setIncreaseNum(rate);
            coin -= needCoin;
            temp1.setCoin(coin);
            updateCounter++;
        }
        else
        {
            
        }

        GameObject.Find("upgrate").GetComponentInChildren<TextMeshProUGUI>().text = nextUpdate;
        GameObject.Find("nowRate").GetComponent<TextMeshProUGUI>().text = nowRate;
    }

}
