using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField]
    private Texture2D cursorBase;
    [SerializeField]
    private Texture2D cursorHold;
    [SerializeField]
    private Texture2D cursorInteract;

    public enum CursorStyle {BASE,HOLD,INTERACT};

    public void ChangeCursor(CursorStyle cursorStyle){
        switch (cursorStyle)
        {
            case CursorStyle.BASE :
                Cursor.SetCursor(cursorBase, Vector2.zero, CursorMode.Auto);
                break;
            case CursorStyle.HOLD :
                Cursor.SetCursor(cursorHold, Vector2.zero, CursorMode.Auto);
                break;
            case CursorStyle.INTERACT : 
                Cursor.SetCursor(cursorInteract, Vector2.zero, CursorMode.Auto);
                break;
            default:
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                break;
        }
    }
}
