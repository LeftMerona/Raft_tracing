using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using Newtonsoft.Json;

#if UNITY_EDITOR
public class JSONtoSOConverter : EditorWindow
{
    private string jsonFilePath = "Assets/0.ETC/Data/"; // 파일 경로 
    private string jsonFileName;
    private string setJson;

    private string outputFolderPath = "Assets/Resources/Data/SO/"; //저장 경로

    // 파일 이름 리스트
    private string[] jsonFileNames = { "Item_Data.json", "Material_Data.json" };
    // 선택된 파일을 저장할 변수
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
        GUILayout.Label("Json 파일의 경로를 설정해주세요", EditorStyles.helpBox);
        GUILayout.Space(20f);
        GUILayout.Label("Select a JSON File:", EditorStyles.boldLabel);

        // 파일 이름과 체크박스를 나열
        for (int i = 0; i < jsonFileNames.Length; i++)
        {
            // 선택된 파일 인덱스를 업데이트 (한 번에 하나만 선택 가능)
            bool isSelected = EditorGUILayout.ToggleLeft(jsonFileNames[i], selectedFileIndex == i);
            if (isSelected && selectedFileIndex != i)
            {
                selectedFileIndex = i; // 새로운 선택
                jsonFileName = jsonFileNames[i];
                setJson = Path.Combine(jsonFilePath, jsonFileName);
                Debug.Log(setJson);
            }
            else if (!isSelected && selectedFileIndex == i)
            {
                selectedFileIndex = -1; // 선택 해제
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

        // 출력 폴더가 존재하지 않으면 생성
        if (!Directory.Exists(outputPath))
        {
            Directory.CreateDirectory(outputPath);
        }

        // JSON 읽기 
        string jsonstring = File.ReadAllText(jsonpath);

        // JSON을 특정 클래스 리스트로 변환
        if (filename.Equals("Item_Data.json"))
        {
            List<Data_Item> itemlist = JsonConvert.DeserializeObject<List<Data_Item>>(jsonstring);

            foreach (var data in itemlist)
            {
                string assetPath = Path.Combine(outputPath, $"{data._img_name}.asset");

                // 이미 존재하는 에셋을 로드
                CompItem itemso = AssetDatabase.LoadAssetAtPath<CompItem>(assetPath);

                if (itemso == null)
                {
                    // 존재하지 않으면 새로 생성
                    itemso = ScriptableObject.CreateInstance<CompItem>();
                    AssetDatabase.CreateAsset(itemso, assetPath);
                }

                // 데이터 업데이트
                itemso.SetData(data);
                string spritepath = $"Sprite/Item_{data._img_name}";
                Debug.Log(spritepath);
                itemso.sprite = Resources.Load<Sprite>(spritepath);

                // 변경된 내용 저장
                EditorUtility.SetDirty(itemso);
            }
        }
        else
        {
            List<Data_Material> materiallist = JsonConvert.DeserializeObject<List<Data_Material>>(jsonstring);

            foreach (var data in materiallist)
            {
                string assetPath = Path.Combine(outputPath, $"{data._img_name}.asset");

                // 이미 존재하는 에셋을 로드
                Materials mateSO = AssetDatabase.LoadAssetAtPath<Materials>(assetPath);

                if (mateSO == null)
                {
                    // 존재하지 않으면 새로 생성
                    mateSO = ScriptableObject.CreateInstance<Materials>();
                    AssetDatabase.CreateAsset(mateSO, assetPath);
                }

                // 데이터 업데이트
                mateSO.SetData(data);
                string spritepath = $"Sprite/Item_{data._img_name}";
                Debug.Log(spritepath);
                mateSO.sprite = Resources.Load<Sprite>(spritepath);

                // 변경된 내용 저장
                EditorUtility.SetDirty(mateSO);
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        //  List<YourDataClass> dataList = JsonConvert.DeserializeObject<List<YourDataClass>>(jsonContent);

    }

}


#endif