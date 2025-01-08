using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DisplayItem : MonoBehaviour
{
    // Ä³½ÌÇØµÎ°í ²¨µÎ°ÚÀ½ 
    [SerializeField] private Image displayImage;
    [SerializeField] private Text displayName;
    [SerializeField] private Text description;

    public void SetEnterDisplay(Sprite sprite, string name, string description)
    {
        displayImage.sprite = sprite;
        displayName.text = name;
        this.description.text = description;

        displayImage.gameObject.SetActive(true);
        displayName.gameObject.SetActive(true);
        this.description.gameObject.SetActive(true);
    }

    public void SetExitDisplay()
    {
        displayImage.gameObject.SetActive(false);
        displayName.gameObject.SetActive(false);
        description.gameObject.SetActive(false);
    }

}
