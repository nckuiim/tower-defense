using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public string heroTurn;

    public string enemyTurn;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy") { callTurn(collision, enemyTurn); }
        else if (collision.gameObject.tag == "Hero") { callTurn(collision, heroTurn); }
    }

    void callTurn(Collision collision, string name)
    {
        switch (name)
        {
            case "up":
                collision.gameObject.GetComponent<Fighter>().up();
                break;
            case "down":
                collision.gameObject.GetComponent<Fighter>().down();
                break;
            case "left":
                collision.gameObject.GetComponent<Fighter>().left();
                break;
            case "right":
                collision.gameObject.GetComponent<Fighter>().right();
                break;
        }
    }
}
