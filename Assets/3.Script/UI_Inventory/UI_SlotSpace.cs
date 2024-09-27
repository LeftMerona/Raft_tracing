using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_SlotSpace : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // 각각 이미지는 있어야하고 수량과 내구도는 있는게 있고 없는게 있다. 
    // 아이템에 대한 설명은 다 있음 
    //  드래그 이벤트 
    // 이건 틀만 있고  각각 상위 오브젝트에서 관리 해주는? 


    // 여기에 스크립트 요소들 다 넣어야되겟다 

    private int _mid;
    private string _mimg_name;
    private string _mname_kr;
    private HandAction _mhandAction;
    private bool _mstackable;
    private int _mmaxstack;
    private bool _mdurability;
    private string _mdescription;

    [SerializeField] private GameObject slot_Image;
    [SerializeField] private GameObject slot_AmountText;
    [SerializeField] private GameObject slot_Sliderdurability;
    private GameObject selectionSlot;
    public GameObject SelectSlot { set => selectionSlot = value; }
    private RectTransform slot_pos;
    public RectTransform slot_Position { get => slot_pos; }

    private bool isSelect = false;


    public void InitSlot()
    {
        slot_Image = transform.GetChild(0).gameObject;
        slot_AmountText = transform.GetChild(1).gameObject;
        slot_Sliderdurability = transform.GetChild(2).gameObject;
        slot_pos = transform.GetComponent<RectTransform>();

        slot_Image.SetActive(false);
        slot_AmountText.SetActive(false);
        slot_Sliderdurability.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // eventData.pointerEnter.name  이걸로 객체 확인 가능 
        isSelect = true;
        selectionSlot.SetActive(true);
        selectionSlot.transform.position = transform.position;

        if (eventData.pointerEnter.gameObject.transform.GetChild(0).gameObject.activeSelf)
        {
  
            
            
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isSelect = false;
        selectionSlot.SetActive(false);
        selectionSlot.transform.position = transform.position;

    }


    public void SetInfoDropItem(int id, string nameEng, string nameKr, HandAction handaction, bool stack, int maxstack, bool dura, string description)
    {
        _mid = id;
        _mimg_name = nameEng;
        _mname_kr = nameKr;
        _mhandAction = handaction;
        _mstackable = stack;
        _mmaxstack = maxstack;
        _mdurability = dura;
        _mdescription  = description;

        slot_Image.GetComponent<Image>().sprite = DataManager.Instance.SetSpriteFromNum(id);
        // slot_AmountText.GetComponent<Text>().text;
        // 이건 수량 
        
    }


}
