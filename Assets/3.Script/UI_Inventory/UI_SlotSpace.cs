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


    [SerializeField] private Image _itemImage; // �̹��� 
    [SerializeField] private Text _amount;     // _stackable�� true ��� 
    private bool _durability;
    [SerializeField] private float _durabilityValue; // ������ ��.. �׽�Ʈ�� 10 ���� 

    private Text _displayitemName;
    private Text _displayiteminfo;


    private void OnMouseEnter()
    {
      
    }
}
