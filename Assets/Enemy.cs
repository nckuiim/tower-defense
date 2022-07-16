using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float HP = 50;
    public static float Atk = 10;
    public static float AtkSpeed = 7;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    Collision colli;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            colli = collision;
        }
    }



    
    public void fight()
    {
        InvokeRepeating("minus", 1, Move.cd);
    }
    
    void minus()
    {
        HP -= Move.ATK;
        Debug.Log("enemy health: " + HP.ToString());
        death();
    }

    public void death()
    {
        if(HP <= 0)
        {
            CancelInvoke();
            Destroy(gameObject);
            colli.gameObject.GetComponent("Move").SendMessage("right");
        }
        else if (Move.HP <= 0)
        {
            CancelInvoke();
        }
    }
    
}
