using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class UI_Hotbar : MonoBehaviour
{
    // ���콺 ��ũ���� �ΰ��Ӷ���, �κ��丮 ������ �ȵ� 
    [SerializeField] GameObject hotbar;
    [SerializeField] GameObject selectionSlot;

    private UI_SlotSpace[] hotbarSlots;
    public UI_SlotSpace[] HotbarSlots { get => hotbarSlots; }


    private int currentindex = 0;

    // private UnityEvent<>
    public Action<int, SoItemBase> OnSlotSelected;


    private void Update()
    {
        float inputwheel = Input.GetAxis("Mouse ScrollWheel");

        if (inputwheel < 0f)
        {
            currentindex -= 1;
            if (currentindex < 0) currentindex = 0;

            NotifySlotSelected();
        }
        else if (inputwheel > 0f)
        {
            currentindex += 1;
            if (currentindex > 9) currentindex = 9;
            NotifySlotSelected();
        }

    }

    private void FixedUpdate()
    {
       selectionSlot.transform.position = hotbarSlots[currentindex].slot_Position.position;
    }


    public void InitHotbar()
    {
        hotbarSlots = new UI_SlotSpace[10];

        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            hotbarSlots[i] = hotbar.transform.GetChild(i).gameObject.AddComponent<UI_SlotSpace>();
            hotbarSlots[i].InitSlot();
            hotbarSlots[i].SetHotbarSlot();
        }
    }

    private void NotifySlotSelected()
    {
        UI_SlotSpace selectedSlot = hotbarSlots[currentindex];

        if (selectedSlot.SlotType.Equals(0)) return;
        if (selectedSlot.ItemSO == null) return;
        OnSlotSelected?.Invoke(currentindex, selectedSlot.ItemSO); // ���õ� ���� ���� ����
    }


}
