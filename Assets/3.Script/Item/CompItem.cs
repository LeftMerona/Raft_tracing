using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class CompItem : SoItemBase
{
    public List<MaterialEntry> materials = new List<MaterialEntry>();
    public string category;

    // Key-Value 구조를 위한 데이터 클래스
    [System.Serializable]
    public class MaterialEntry
    {
        public string materialName;
        public int quantity;
    }


    public void SetData(Data_Item data)
    {
        id = data._id;
        img_name = data._img_name;
        name_kr = data._name_kr;
        handAction = data._handAction;
        stackable = data._stackable;
        maxstack = data._maxstack;

        materials.Clear();

        foreach (var material in data._materials)
        {
            materials.Add(new MaterialEntry { materialName = material.Key, quantity = material.Value });
        }

        category = data._category;
        durability = data._durability;
        description = data._description;
    }

    // Dictionary 변환 메서드
    public Dictionary<string, int> GetMaterialsAsDictionary()
    {
        Dictionary<string, int> materialsDict = new Dictionary<string, int>();
        foreach (var material in materials)
        {
            materialsDict[material.materialName] = material.quantity;
        }
        return materialsDict;
    }


}
