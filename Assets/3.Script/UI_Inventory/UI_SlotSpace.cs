using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SlotSpace : MonoBehaviour
{
    // 각각 이미지는 있어야하고 수량과 내구도는 있는게 있고 없는게 있다. 
    // 아이템에 대한 설명은 다 있음 


    [SerializeField] private Image _itemImage;
    [SerializeField] private Text _amount;
    [SerializeField] private float _durability;

    private Text _displayitemName;
    private Text _displayiteminfo;


    private void OnMouseEnter()
    {
      
    }
}
