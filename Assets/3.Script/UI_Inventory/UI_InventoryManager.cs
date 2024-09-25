using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InventoryManager : MonoBehaviour
{
    [SerializeField] private UI_InventoryPlayer inventoryPlayer;
    [SerializeField] private UI_Hotbar hotbar;
    [SerializeField] private GameObject craftmenu; // 크래프팅 추가 


    [SerializeField] private CursorManager cursorManager;


    private void Start()
    {
        if (inventoryPlayer.gameObject.activeSelf)
        {
            inventoryPlayer.gameObject.SetActive(false);
            craftmenu.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TabControlUI();
        }
    }


    private void TabControlUI()
    {
        if (inventoryPlayer.gameObject.activeSelf && craftmenu.activeSelf)
        {
            inventoryPlayer.gameObject.SetActive(false);
            craftmenu.SetActive(false);
            cursorManager.CloseInventoryCursorSet();
        }
        else
        {
            inventoryPlayer.gameObject.SetActive(true);
            craftmenu.SetActive(true);
            cursorManager.OpenInventoryCursorSet();
            
        }
    }
}
