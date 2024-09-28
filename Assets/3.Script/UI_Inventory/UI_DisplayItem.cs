using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DisplayItem : MonoBehaviour
{
    [SerializeField] private GameObject displayImageob;
    [SerializeField] private GameObject displayNameob;
    [SerializeField] private GameObject descriptionob;

    private Image displayImage;
    private Text displayName;
    private Text description;
    
    public void Init()
    {
        displayImage = displayImageob.GetComponent<Image>();
        displayName = displayNameob.GetComponent<Text>();
        description = descriptionob.GetComponent<Text>();

        displayImageob.SetActive(false);
        displayNameob.SetActive(false);
        descriptionob.SetActive(false);
    }

    public void SetEnterDisplay(Image image, string name, string description)
    {
        displayImage.sprite = image.sprite;
        displayName.text = name;
        this.description.text = description;

        displayImageob.SetActive(true);
        displayNameob.SetActive(true);
        descriptionob.SetActive(true);
    }

    public void SetExitDisplay()
    {
        displayImageob.SetActive(false);
        displayNameob.SetActive(false);
        descriptionob.SetActive(false);
    }

}
