using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InventoryPlayer : MonoBehaviour
{
    // 탭키로 활성화 시 마우스 나오면서 슬롯에 마우스 올라가면 그 선택한거 돌아다님 hover 오브젝트 잇음 

    // 이거따로 옆에 카테고리 따로 해야할듯 
    // 슬롯 온마우스오바로  hover하고 
    // 이건 배열 해도 될거같고 리스트는 아닌거 같고 ㅇㅋ 

    [SerializeField] GameObject selectionSlot;

    private UI_SlotSpace[] inventoryslots;

    private int currentindex = 0;

    private void Awake()
    {
        inventoryslots = new UI_SlotSpace[15];

         
    }

}
