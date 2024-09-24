using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InventoryPlayer : MonoBehaviour
{
    // ��Ű�� Ȱ��ȭ �� ���콺 �����鼭 ���Կ� ���콺 �ö󰡸� �� �����Ѱ� ���ƴٴ� hover ������Ʈ ���� 

    // �̰ŵ��� ���� ī�װ� ���� �ؾ��ҵ� 
    // ���� �¸��콺���ٷ�  hover�ϰ� 
    // �̰� �迭 �ص� �ɰŰ��� ����Ʈ�� �ƴѰ� ���� ����     

    [SerializeField] GameObject selectionSlot;

    private UI_SlotSpace[] inventoryslots;
    [SerializeField] private UI_Hotbar hotbar; 

    private int currentindex = 0;

    private void Awake()
    {
        InitInventory();        
    }




    

    private void InitInventory()
    {
        inventoryslots = new UI_SlotSpace[15];
        for (int i = 0; i < inventoryslots.Length; i++)
        {
            inventoryslots[i] = hotbar.transform.GetChild(i).gameObject.AddComponent<UI_SlotSpace>();
            inventoryslots[i].InitSlot();
        }
        hotbar = FindObjectOfType<UI_Hotbar>();
    }

}
