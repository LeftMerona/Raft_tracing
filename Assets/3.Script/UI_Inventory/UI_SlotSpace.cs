using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_SlotSpace : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // ���� �̹����� �־���ϰ� ������ �������� �ִ°� �ְ� ���°� �ִ�. 
    // �����ۿ� ���� ������ �� ���� 
    //  �巡�� �̺�Ʈ 
    // �̰� Ʋ�� �ְ�  ���� ���� ������Ʈ���� ���� ���ִ�? 


    // ���⿡ ��ũ��Ʈ ��ҵ� �� �־�ߵǰٴ� 
    [SerializeField] private SoItemBase itemso;


    [SerializeField] private Image slot_Image;
    [SerializeField] private Text slot_AmountText;
    [SerializeField] private Slider slot_Sliderdurability;

    //�̰� InventoryPlayer���� �ʱ�ȭ �Ҷ� ������ 
    private GameObject selectionSlot;

    private RectTransform slot_pos;
    public RectTransform slot_Position { get => slot_pos; }

    private UI_DisplayItem slot_display;

    private bool isSelect = false;

    public void SetselectionSlot(GameObject selectslot, UI_DisplayItem display)
    {
        selectionSlot = selectslot;
        slot_display = display;
    }


    public void InitSlot()
    {
        transform.GetChild(0).TryGetComponent(out slot_Image);
        transform.GetChild(1).TryGetComponent(out slot_AmountText);
        transform.GetChild(2).TryGetComponent(out slot_Sliderdurability);
        transform.TryGetComponent(out slot_pos);

        slot_Image.gameObject.SetActive(false);
        slot_AmountText.gameObject.SetActive(false);
        slot_Sliderdurability.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // eventData.pointerEnter.name  �̰ɷ� ��ü Ȯ�� ���� 
        isSelect = true;
        selectionSlot.SetActive(true);
        selectionSlot.transform.position = transform.position;

        if (!itemso.Equals(null))
        {
            slot_display.SetEnterDisplay(itemso.sprite, itemso.name_kr, itemso.description);
        }        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isSelect = false;
        selectionSlot.SetActive(false);
        selectionSlot.transform.position = transform.position;

        if (!itemso.Equals(null))
        {
            slot_display.SetExitDisplay();
        }

    }

    public void SetInfoDropItem(ScriptableObject so)
    {


      //  slot_Image.GetComponent<Image>().sprite = DataManager.Instance.SetSpriteFromNum(id);
        // slot_AmountText.GetComponent<Text>().text;
        // �̰� ���� 

    }


}
