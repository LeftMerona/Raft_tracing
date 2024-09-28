using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_InventoryPlayer : MonoBehaviour
{
    // ��Ű�� Ȱ��ȭ �� ���콺 �����鼭 ���Կ� ���콺 �ö󰡸� �� �����Ѱ� ���ƴٴ� hover ������Ʈ ���� 

    // �̰ŵ��� ���� ī�װ� ���� �ؾ��ҵ� 
    // ���� �¸��콺���ٷ�  hover�ϰ� 
    // �̰� �迭 �ص� �ɰŰ��� ����Ʈ�� �ƴѰ� ���� ����     

    [SerializeField] GameObject selectionSlot; //�־�־� 
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
