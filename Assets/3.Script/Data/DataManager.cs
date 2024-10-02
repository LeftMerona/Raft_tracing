using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Linq;
using UnityEditor;
using GLTFast.Schema;


public class DataManager : MonoBehaviour
{
    public static DataManager Instance = null;

    private Dictionary<int, Data_Material> dicData_Material;
    private Dictionary<int, Sprite> dicsprite;
    private List<Materials> listmaterials;

    private Dictionary<int, Data_Item> dicData_Item;
    private List<Item> listItems;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Init_Data();
        Load_AllData();
    }


    private void Init_Data()
    {
        dicData_Material = new Dictionary<int, Data_Material>();
        dicsprite = new Dictionary<int, Sprite>();
        listmaterials = new List<Materials>();
        dicData_Item = new Dictionary<int, Data_Item>();
        listItems = new List<Item>();

    }


    private void Load_AllData()
    {
        Load_MaterialsData();
        Load_ItemData();

    }

    private void Load_MaterialsData()
    {
        string material_json = Resources.Load<TextAsset>("Data/Material_Data").text;
        dicData_Material = JsonConvert.DeserializeObject<Data_Material[]>(material_json).ToDictionary(x => x._id, x => x);

        foreach (KeyValuePair<int, Data_Material> dicMate in dicData_Material)
        {
            Materials matetials = ScriptableObject.CreateInstance<Materials>();
            matetials._id = dicMate.Key;
            matetials._img_name = dicMate.Value._img_name;
            matetials._name_kr = dicMate.Value._name_kr;
            matetials._handAction = dicMate.Value._handAction;
            matetials._stackable = dicMate.Value._stackable;
            matetials._maxstack = dicMate.Value._maxstack;
            matetials._durability = dicMate.Value._durability;
            matetials._description = dicMate.Value._description;

            matetials.name = matetials._img_name;

            string itempath = $"Sprite/Item_{dicMate.Value._img_name}";
            Sprite itemsprite = Resources.Load<Sprite>(itempath);
            dicsprite.Add(dicMate.Key, itemsprite);
            this.listmaterials.Add(matetials);
            AssetDatabase.CreateAsset(matetials, $"Assets/Resources/InGame_Materials/{matetials.name}.asset");
            AssetDatabase.SaveAssets();

        }


    }

    private void Load_ItemData()
    {
        string item_json = Resources.Load<TextAsset>("Data/Item_Data").text;
        dicData_Item = JsonConvert.DeserializeObject<Data_Item[]>(item_json).ToDictionary(x => x._id, x => x);
       
 

        foreach (KeyValuePair<int, Data_Item> dicitem in dicData_Item)
        {
            Item item = ScriptableObject.CreateInstance<Item>();
            item._id = dicitem.Key;
            item._img_name = dicitem.Value._img_name;
            item._name_kr = dicitem.Value._name_kr;
            item._handAction = dicitem.Value._handAction;
            item._stackable = dicitem.Value._stackable;
            item._maxstack = dicitem.Value._maxstack;
            item._category = dicitem.Value._category;
            item._durability = dicitem.Value._durability;
            item._description = dicitem.Value._description;

            item._materials = new Dictionary<string, int>();
            foreach (KeyValuePair<string, int> itemmate in dicitem.Value._materials)
            {
                item._materials.Add(itemmate.Key, itemmate.Value);
            }

            item.name = item._img_name;
            string itmepath = $"Sprite/Itme_{dicitem.Value._img_name}";
            Sprite itemsprite = Resources.Load<Sprite>(itmepath);
            dicsprite.Add(dicitem.Key, itemsprite);
            listItems.Add(item);
            AssetDatabase.CreateAsset(item, $"Assets/Resources/InGame_Materials/{item.name}.asset");
            AssetDatabase.SaveAssets();
        }
    }

    public Dictionary<int, Data_Material> GetMaterialsData()
    {
        return dicData_Material;
    }

    public Data_Material GetMaterialFromNum(int num)
    {
        return dicData_Material[num];
    }

    public Dictionary<int, Sprite> GetSpriteData()
    {
        return dicsprite;
    }

    public Sprite SetSpriteFromNum(int num)
    {
        return dicsprite[num];
    }

}
