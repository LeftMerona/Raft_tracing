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

    private int currentindex = 0;

    private void Awake()
    {
        inventoryslots = new UI_SlotSpace[15];

         
    }

}
