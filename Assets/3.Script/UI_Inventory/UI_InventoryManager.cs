using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InventoryManager : MonoBehaviour
{
    [SerializeField] private UI_InventoryPlayer inventoryPlayer;
    [SerializeField] private UI_Hotbar hotbar;
    [SerializeField] private GameObject craftmenu; // 크래프팅 추가 
    [SerializeField] private CursorManager cursorManager;

    private int plankAmount;
    private int plasticAmount;
    private int thatchAmount;


    // 스크립테이블 오브젝트 활용을 위해 좀 더 찾아보거나 
    // 팩토리 패턴? 이건 굳이 ? 흠 ? 할까 ? 

    private void Awake()
    {
        inventoryPlayer.InitInventory();
    }

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
