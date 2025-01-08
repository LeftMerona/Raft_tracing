using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials : SoItemBase
{

    public void SetData(Data_Material data)
    {
        id = data._id;
        img_name = data._img_name;
        name_kr = data._name_kr;
        handAction = data._handAction;
        stackable = data._stackable;
        maxstack = data._maxstack;
        durability = data._durability;
        description = data._description;
    }
}
   