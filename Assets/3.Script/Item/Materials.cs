using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials : ScriptableObject
{
    public int _id;
    public string _img_name;
    public string _name_kr;
    public HandAction _handAction;
    public bool _stackable;
    public int _maxstack;
    public bool _durability;
    public string _description;
}
   