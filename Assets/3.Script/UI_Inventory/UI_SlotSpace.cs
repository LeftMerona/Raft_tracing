using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SlotSpace : MonoBehaviour
{
    // ���� �̹����� �־���ϰ� ������ �������� �ִ°� �ְ� ���°� �ִ�. 
    // �����ۿ� ���� ������ �� ���� 

    //  �巡�� �̺�Ʈ 

    // �̰� Ʋ�� �ְ�  ���� ���� ������Ʈ���� ���� ���ִ�? 


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
