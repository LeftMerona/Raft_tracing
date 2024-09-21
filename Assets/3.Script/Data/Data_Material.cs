using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HandAction
{
    none = 0,
    finger,
    hand
}

public class Data_Material 
{
    public int _id;
    public string _img_name;
    public string _name_kr;
    public HandAction _handAction;
    public bool _stackable; // ÁßÃ¸µÇ´Â°¡? 
    public int _maxstack;   // °ãÄ¡´Â ¸Æ½º 
    public bool _durability; // ³»±¸µµ 
    public string _description; // ¼³¸í 
}
