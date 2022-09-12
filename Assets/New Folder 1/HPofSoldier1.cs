using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HPofSoldier1 : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI HPTextS;
    [SerializeField] public static float hpS = 200;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SOlDIER START");
        Debug.Log(HPTextS.GetType());
        
        HPChangeS();
        Debug.Log("OVER HPCHANGE");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void HPChangeS()
    {
        HPTextS.text = hpS.ToString();
    }

}
