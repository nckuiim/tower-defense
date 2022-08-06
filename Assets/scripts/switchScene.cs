using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchScene : MonoBehaviour
{
    public void OnMouseDown()
    {
        string buttonName = gameObject.name;
        switch (buttonName)
        {
            case "level 1":
                SceneManager.LoadScene("level 1");
                Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
                break;
            default:
                Debug.Log("scene not exist");
                break;
        }
    }

}
