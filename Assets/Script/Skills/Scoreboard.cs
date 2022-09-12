using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoreboard : MonoBehaviour
{

    public TextMeshProUGUI Showscore;
    public static int sc = 0;

    // Start is called before the first frame update
    void Start()
    {
        Showscore = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Showscore.text = sc.ToString();
    }
}
