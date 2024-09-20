using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;
using UnityEditor;
using System.IO;

// �Ź� DataManager�� ��𼭵� �̾ƾ���� 
// �̱������� ������ߴµ� �̰� �ѹ� ��ü���� �����ϰ� ���ǵ� �ʿ䰡 �ֳ� ? �� ���� 
// �׷��� �̱��� ���� �ѹ� �������� 

public class DataManager : MonoBehaviour
{
  //  public static DataManager Instance = null;

    private Dictionary<int, Data_Material> dicData_Material;
    private List<Data_Material> list_Materials;

    private void Awake()
    {
        //if (Instance == null)
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}

        Init_Data();
        Load_AllData();
    }


    private void Init_Data()
    {
        dicData_Material = new Dictionary<int, Data_Material>();

    }


    private void Load_AllData()
    {
        // �� �κ��� üũ �Ҷ����� �� �ɸ��ϱ� �׽�Ʈ�� 
        string checkpath = "Assets/Resources/InGame_Materials/Plank.asset";

        if (File.Exists(checkpath))
        {
            Debug.Log("�̹� ���� ���� ����");
            return;
        }

        Load_MaterialsData();
     
    }

    private void Load_MaterialsData()
    {
        string material_json = Resources.Load<TextAsset>("Data/Material_Data").text;
        dicData_Material = JsonConvert.DeserializeObject<Data_Material[]>(material_json).ToDictionary(x => x._id, x => x);
        list_Materials = dicData_Material.Values.ToList();

        for (int i = 0; i < list_Materials.Count; i++)
        {
            Materials matetials = ScriptableObject.CreateInstance<Materials>();
            matetials._img_name = list_Materials[i]._img_name;
            matetials._name_kr = list_Materials[i]._name_kr;
            matetials._handAction = list_Materials[i]._handAction;
            matetials._stackable = list_Materials[i]._stackable;
            matetials._maxstack = list_Materials[i]._maxstack;
            matetials._durability = list_Materials[i]._durability;
            matetials._description = list_Materials[i]._description;

            matetials.name = matetials._img_name;
            AssetDatabase.CreateAsset(matetials, $"Assets/Resources/InGame_Materials/{matetials.name}.asset");
            AssetDatabase.SaveAssets();
        }
    }


}
