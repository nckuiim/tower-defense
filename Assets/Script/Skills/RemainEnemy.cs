using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RemainEnemy : MonoBehaviour
{

    public TextMeshProUGUI ShowRemaining;
    public static int en = 46;
    // Start is called before the first frame update
    void Start()
    {
        ShowRemaining = GetComponent<TextMeshProUGUI> ();
    }

    // Update is called once per frame
    void Update()
    {
        ShowRemaining.text = en.ToString();
    }
}
