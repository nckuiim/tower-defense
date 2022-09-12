using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShootingDamage : MonoBehaviour
{

    [SerializeField] public TextMeshProUGUI DamageText;
    [SerializeField] public static float theDamage = 0;
    // Start is called before the first frame update
    void Start()
    {
        //DamageChange();
        //gameObject.transform.Translate(40f, 10f, 0);
        gameObject.transform.Translate(40f, 200f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageChange()
    {
        DamageText.text = theDamage.ToString();

        gameObject.transform.Translate(-40f, -200f , 0);

        Invoke("littleMove", 0.1f);
        Invoke("littleMove", 0.2f);
        Invoke("littleMove", 0.3f);
        Invoke("littleMove", 0.4f);
        Invoke("littleMove", 0.5f);
        Invoke("littleMove", 0.6f);
        Invoke("littleMove", 0.7f);
        Invoke("littleMove", 0.8f);
        Invoke("littleMove", 0.9f);
        Invoke("littleMove", 1.0f);
        Invoke("moveOut", 1.1f);



    }
    public void littleMove()
    {
        transform.Translate(0, 10f /* Time.deltaTime*/, 0);
    }
    public void moveOut()
    {
        gameObject.transform.Translate(40f, 100f, 0);
    }
}
