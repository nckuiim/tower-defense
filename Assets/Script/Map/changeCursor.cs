using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCursor : MonoBehaviour
{
    [SerializeField] Texture2D cursor;

    public void OnMouseEnter()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }
}
