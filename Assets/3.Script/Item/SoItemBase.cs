using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoItemBase : ScriptableObject
{
    public int id;
    public string img_name;
    public string name_kr;
    public HandAction handAction;
    public bool stackable;
    public int maxstack;
    public bool durability;
    public string description;
    public Sprite sprite;



}
