using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Linq;
using UnityEditor;


public class DataManager : MonoBehaviour
{
    public static DataManager Instance = null;

    private Dictionary<int, Data_Material> dicData_Material;
    private Dictionary<int, Sprite> dicsprite;
    private List<Materials> listmaterials;

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

    }


    private void Load_AllData()
    {
        Load_MaterialsData();

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
