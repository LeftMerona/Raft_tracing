using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using Newtonsoft.Json;

#if UNITY_EDITOR
public class JSONtoSOConverter : EditorWindow
{
    private string jsonFilePath = "Assets/0.ETC/Data/"; // ���� ��� 
    private string jsonFileName;
    private string setJson;

    private string outputFolderPath = "Assets/Resources/Data/SO/"; //���� ���

    // ���� �̸� ����Ʈ
    private string[] jsonFileNames = { "Item_Data.json", "Material_Data.json" };
    // ���õ� ������ ������ ����
    private int selectedFileIndex = -1;

    [MenuItem("Tools/Json to SO Converter")]

    public static void ShowWindow()
    {
        GetWindow<JSONtoSOConverter>("Json to SO");
    }

    private void OnGUI()
    {
        GUILayout.Label("Json to SO Converter", EditorStyles.boldLabel);
        GUILayout.Space(20f);
        jsonFilePath = EditorGUILayout.TextField("CSV File Path : ", jsonFilePath);
        GUILayout.Label("Json ������ ��θ� �������ּ���", EditorStyles.helpBox);
        GUILayout.Space(20f);
        GUILayout.Label("Select a JSON File:", EditorStyles.boldLabel);

        // ���� �̸��� üũ�ڽ��� ����
        for (int i = 0; i < jsonFileNames.Length; i++)
        {
            // ���õ� ���� �ε����� ������Ʈ (�� ���� �ϳ��� ���� ����)
            bool isSelected = EditorGUILayout.ToggleLeft(jsonFileNames[i], selectedFileIndex == i);
            if (isSelected && selectedFileIndex != i)
            {
                selectedFileIndex = i; // ���ο� ����
                jsonFileName = jsonFileNames[i];
                setJson = Path.Combine(jsonFilePath, jsonFileName);
                Debug.Log(setJson);
            }
            else if (!isSelected && selectedFileIndex == i)
            {
                selectedFileIndex = -1; // ���� ����
            }
        }

        if (GUILayout.Button("Convert"))
        {
            ConverterJsonToSO(setJson, jsonFileName, outputFolderPath);
        }
    }

    private void ConverterJsonToSO(string jsonpath, string filename, string outputPath)
    {
        if (!File.Exists(jsonpath))
        {
            Debug.LogError("Json file not found at : " + jsonpath);
            return;
        }

        // ��� ������ �������� ������ ����
        if (!Directory.Exists(outputPath))
        {
            Directory.CreateDirectory(outputPath);
        }

        // JSON �б� 
        string jsonstring = File.ReadAllText(jsonpath);

        // JSON�� Ư�� Ŭ���� ����Ʈ�� ��ȯ
        if (filename.Equals("Item_Data.json"))
        {
            List<Data_Item> itemlist = JsonConvert.DeserializeObject<List<Data_Item>>(jsonstring);

            foreach (var data in itemlist)
            {
                string assetPath = Path.Combine(outputPath, $"{data._img_name}.asset");

                // �̹� �����ϴ� ������ �ε�
                CompItem itemso = AssetDatabase.LoadAssetAtPath<CompItem>(assetPath);

                if (itemso == null)
                {
                    // �������� ������ ���� ����
                    itemso = ScriptableObject.CreateInstance<CompItem>();
                    AssetDatabase.CreateAsset(itemso, assetPath);
                }

                // ������ ������Ʈ
                itemso.SetData(data);
                string spritepath = $"Sprite/Item_{data._img_name}";
                Debug.Log(spritepath);
                itemso.sprite = Resources.Load<Sprite>(spritepath);

                // ����� ���� ����
                EditorUtility.SetDirty(itemso);
            }
        }
        else
        {
            List<Data_Material> materiallist = JsonConvert.DeserializeObject<List<Data_Material>>(jsonstring);

            foreach (var data in materiallist)
            {
                string assetPath = Path.Combine(outputPath, $"{data._img_name}.asset");

                // �̹� �����ϴ� ������ �ε�
                Materials mateSO = AssetDatabase.LoadAssetAtPath<Materials>(assetPath);

                if (mateSO == null)
                {
                    // �������� ������ ���� ����
                    mateSO = ScriptableObject.CreateInstance<Materials>();
                    AssetDatabase.CreateAsset(mateSO, assetPath);
                }

                // ������ ������Ʈ
                mateSO.SetData(data);
                string spritepath = $"Sprite/Item_{data._img_name}";
                Debug.Log(spritepath);
                mateSO.sprite = Resources.Load<Sprite>(spritepath);

                // ����� ���� ����
                EditorUtility.SetDirty(mateSO);
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        //  List<YourDataClass> dataList = JsonConvert.DeserializeObject<List<YourDataClass>>(jsonContent);

    }

}


#endif