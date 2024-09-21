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


    [SerializeField] private Image _itemImage; // 이미지 
    [SerializeField] private Text _amount;     // _stackable이 true 라면 
    private bool _durability;
    [SerializeField] private float _durabilityValue; // 내구도 흠.. 테스트차 10 으로 

    private Text _displayitemName;
    private Text _displayiteminfo;


    private void OnMouseEnter()
    {
      
    }
}
