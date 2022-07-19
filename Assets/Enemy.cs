using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float HP = 100;
    public static float Atk = 1;
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
            InvokeRepeating("fight", 1, AtkSpeed);
        }
    }

    public float getHP()
    { return HP; }

    
    public void fight()
    {
        Atk = 10;
        colli.gameObject.GetComponent<Hero>().Invoke("damage", 1);
        //InvokeRepeating("minus", 1, Move.cd);
    }
    
    public void minus(float atk, int atkType)
    {
        HP -= atk;
        Debug.Log("enemy health: " + HP.ToString());
        death();
    }

    public void death()
    {
        if(HP <= 0)
        {
            CancelInvoke();
            Destroy(gameObject);
            //colli.gameObject.GetComponent<Hero>().Invoke("right",0.5f);
            colli.gameObject.GetComponent<Hero>().CancelInvoke();
        }
        else if (Move.HP <= 0)
        {
            CancelInvoke();
        }
    }
    
}
