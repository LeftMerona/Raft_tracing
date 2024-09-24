using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] Texture2D cursorImage;
    private bool isOpen = false;
    public bool IsOpen { get { return isOpen; } }

    private void Start()
    {
        StartGameSursorSet();
    }

    public void StartGameSursorSet()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void CloseInventoryCursorSet()
    {
        isOpen = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenInventoryCursorSet()
    {
        isOpen = true;
        Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.ForceSoftware);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
