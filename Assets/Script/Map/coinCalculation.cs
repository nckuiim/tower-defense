using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class coinCalculation : MonoBehaviour
{
    [SerializeField] int increaseNum;
    GameObject tower1;
    GameObject tower2;
    GameObject tower3;
    GameObject tower4;
    Color co1;
    Color co2;
    Color co3;
    Color co4;
    public TextMeshProUGUI showCoin;
    public static int coin;
    float coinTime;
    // Start is called before the first frame update
    void Start()
    {
        coin = 0;
        coinTime = 0;
        increaseNum = 30;
        showCoin = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        increaseCoin();
        whetherEnough();
    }

    public void increaseCoin() //每一秒增加increaseNum金幣
    {
        coinTime += Time.deltaTime;
        if (coinTime > 1f)
        {
            coin += increaseNum;
            coinTime = 0;
            showCoin.text = coin.ToString();
        }
    }

    public void whetherEnough() //檢查每個時刻塔模板的透明度
    {
        tower1 = GameObject.Find("tower1Base");
        co1 = tower1.GetComponent<SpriteRenderer>().color;
        tower2 = GameObject.Find("tower2Base");
        co2 = tower2.GetComponent<SpriteRenderer>().color;
        tower3 = GameObject.Find("tower3Base");
        co3 = tower3.GetComponent<SpriteRenderer>().color;
        tower4 = GameObject.Find("tower4Base");
        co4 = tower4.GetComponent<SpriteRenderer>().color;

        if (coin >= 25 && coin < 75)
        {
            co1.a = 1f;
            co2.a = 0.4f;
            co3.a = 0.4f;
            co4.a = 0.4f;
        }
        else if(coin >= 75 && coin < 150)
        {
            co1.a = 1f;
            co2.a = 1f;
            co3.a = 0.4f;
            co4.a = 0.4f;
        }
        else if(coin >= 150 && coin < 250)
        {
            co1.a = 1f;
            co2.a = 1f;
            co3.a = 1f;
            co4.a = 0.4f;
        }
        else if(coin >= 250)
        {
            co1.a = 1f;
            co2.a = 1f;
            co3.a = 1f;
            co4.a = 1f;
        }
        else
        {
            co1.a = 0.4f;
            co2.a = 0.4f;
            co3.a = 0.4f;
            co4.a = 0.4f;
        }

        tower1.GetComponent<SpriteRenderer>().color = co1;
        tower2.GetComponent<SpriteRenderer>().color = co2;
        tower3.GetComponent<SpriteRenderer>().color = co3;
        tower4.GetComponent<SpriteRenderer>().color = co4;
    }

    public int getCoin() //回傳金幣數量
    {
        return coin;
    }

    public int getIncreaseNum()
    {
        return increaseNum;
    }

    public void setCoin(int currentCoin)
    {
        coin = currentCoin;
        showCoin.text = coin.ToString();
    }

    public void setIncreaseNum(int currentIncreaseNum)
    {
        increaseNum = currentIncreaseNum;
    }
}
