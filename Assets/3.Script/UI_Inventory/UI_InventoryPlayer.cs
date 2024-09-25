using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InventoryPlayer : MonoBehaviour
{
    // ��Ű�� Ȱ��ȭ �� ���콺 �����鼭 ���Կ� ���콺 �ö󰡸� �� �����Ѱ� ���ƴٴ� hover ������Ʈ ���� 

    // �̰ŵ��� ���� ī�װ� ���� �ؾ��ҵ� 
    // ���� �¸��콺���ٷ�  hover�ϰ� 
    // �̰� �迭 �ص� �ɰŰ��� ����Ʈ�� �ƴѰ� ���� ����     

    [SerializeField] GameObject selectionSlot; //�־�־� 

    private UI_SlotSpace[] inventoryslots;
    [SerializeField] private GameObject inventoryPrarent; 
    [SerializeField] private UI_Hotbar hotbar;

    private List<UI_SlotSpace> slotlist;


    private void Awake()
    {
        hotbar = FindObjectOfType<UI_Hotbar>();
        hotbar.InitHotbar();
        InitInventory();
    }

    public void InitInventory()
    {
        inventoryslots = new UI_SlotSpace[15];

        for (int i = 0; i < inventoryslots.Length; i++)
        {
            inventoryslots[i] = inventoryPrarent.transform.GetChild(i + 1).gameObject.AddComponent<UI_SlotSpace>();
            inventoryslots[i].InitSlot();
            inventoryslots[i].SelectSlot = selectionSlot;
        }


        for (int i = 0; i < hotbar.HotbarSlots.Length; i++)
        {
            hotbar.HotbarSlots[i].SelectSlot = selectionSlot;
        }

    }






}
