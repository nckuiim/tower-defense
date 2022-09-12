using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;



public class HPofTower1 : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI HPText;
    [SerializeField] public static float hp = 100;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TANK START");
        Debug.Log(HPText.GetType());
        HPChange();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HPChange()
    {
        HPText.text = hp.ToString();
    }
}
