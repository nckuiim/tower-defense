using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DataBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public TextMeshProUGUI basicDataText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showSoldier1Data()
    {
        basicDataText.text = Character1.basicData;
        Invoke("clearDataBar", 5.0f);
    }
    public void showQQManData()
    {
        basicDataText.text = QQMan.basicData;
        Invoke("clearDataBar", 5.0f);
    }

    public void clearDataBar()
    {
        basicDataText.text = "*";
    }
}
