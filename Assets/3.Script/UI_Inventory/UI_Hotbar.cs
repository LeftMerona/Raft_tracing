using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Hotbar : MonoBehaviour
{
    // 마우스 스크롤은 인게임때만, 인벤토리 떳으면 안됨 
    [SerializeField] GameObject hotbar;
    [SerializeField] GameObject selectionSlot;

    private UI_SlotSpace[] hotbarSlots;
    public UI_SlotSpace[] HotbarSlots { get => hotbarSlots; }

    private int currentindex = 0;

    private void Awake()
    {
        InitHotbar();

    }

    private void Update()
    {
        float inputwheel = Input.GetAxis("Mouse ScrollWheel");

        if (inputwheel < 0f)
        {
            currentindex -= 1;
            if (currentindex < 0) currentindex = 0;
        }
        else if (inputwheel > 0f)
        {
            currentindex += 1;
            if (currentindex > 9) currentindex = 9;
        }

    }

    private void FixedUpdate()
    {
       selectionSlot.transform.position = hotbarSlots[currentindex].slot_Position.position;
    }


    private void InitHotbar()
    {
        hotbarSlots = new UI_SlotSpace[10];

        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            hotbarSlots[i] = hotbar.transform.GetChild(i).gameObject.AddComponent<UI_SlotSpace>();
            hotbarSlots[i].InitSlot();
        }
    }


}
