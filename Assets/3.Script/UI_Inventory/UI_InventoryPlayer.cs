using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_InventoryPlayer : MonoBehaviour
{
    // 탭키로 활성화 시 마우스 나오면서 슬롯에 마우스 올라가면 그 선택한거 돌아다님 hover 오브젝트 잇음 

    // 이거따로 옆에 카테고리 따로 해야할듯 
    // 슬롯 온마우스오바로  hover하고 
    // 이건 배열 해도 될거같고 리스트는 아닌거 같고 ㅇㅋ     

    [SerializeField] GameObject selectionSlot; //넣어둬씀 
    [SerializeField] private UI_DisplayItem display;

    private UI_SlotSpace[] inventoryslots;
    [SerializeField] private GameObject inventoryPrarent; 
    [SerializeField] private UI_Hotbar hotbar;

    public void InitInventory()
    {
        hotbar.InitHotbar();
        inventoryslots = new UI_SlotSpace[15];
        display.Init();
        

        for (int i = 0; i < inventoryslots.Length; i++)
        {
            inventoryslots[i] = inventoryPrarent.transform.GetChild(i + 1).gameObject.AddComponent<UI_SlotSpace>();
            inventoryslots[i].InitSlot();
            inventoryslots[i].SelectSlot = selectionSlot;
            inventoryslots[i].Slot_Display = display;
        }


        for (int i = 0; i < hotbar.HotbarSlots.Length; i++)
        {
            hotbar.HotbarSlots[i].SelectSlot = selectionSlot;
            hotbar.HotbarSlots[i].Slot_Display = display;

        }
    }


}
