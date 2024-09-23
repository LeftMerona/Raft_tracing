using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SlotSpace : MonoBehaviour
{
    // 각각 이미지는 있어야하고 수량과 내구도는 있는게 있고 없는게 있다. 
    // 아이템에 대한 설명은 다 있음 

    //  드래그 이벤트 

    // 이건 틀만 있고  각각 상위 오브젝트에서 관리 해주는? 


    [SerializeField] private GameObject slot_Image;
    [SerializeField] private GameObject slot_AmountText;
    [SerializeField] private GameObject slot_Sliderdurability;
    private RectTransform slot_pos;
    public RectTransform slot_Position { get => slot_pos; }

    private Text _displayitemName;
    private Text _displayiteminfo;


    private bool isTabOpen = false;

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


}
