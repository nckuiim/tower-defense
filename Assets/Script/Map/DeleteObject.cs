using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    [SerializeField] GameObject objecttodestroy;
   
    public void OnMouseDown()
    {
        DestroyGameobject();
    }

    public void DestroyGameobject()
    {

        Destroy (objecttodestroy);
    }
    


}
