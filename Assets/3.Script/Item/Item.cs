using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public int _id;
    public string _img_name;
    public string _name_kr;
    public HandAction _handAction;
    public bool _stackable;
    public int _maxstack;
    public Dictionary<string, int> _materials;
    public string _category;
    public bool _durability;
    public string _description;
}
