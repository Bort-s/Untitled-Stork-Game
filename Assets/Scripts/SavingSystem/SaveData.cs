using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour
{
    private string filePath;
    private USGData usgData;
    private int[] localRecords = new int[6];

    private void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "save_data.json");
    }

    void Start()
    {
        if (File.Exists(filePath))
        {
            string loadJson = File.ReadAllText(filePath);
            usgData = JsonUtility.FromJson<USGData>(loadJson);

            if (usgData == null || usgData.records == null || usgData.records.Length != 5)
            {
                usgData = new USGData();
            }

            localRecords[0] = (int)WinData.score;

            for (int i = 1; i < 6; i++)
            {
                localRecords[i] = usgData.records[i - 1];
            }

            System.Array.Sort(localRecords);
            System.Array.Reverse(localRecords);

            for (int i = 0; i < 5; i++)
            {
                usgData.records[i] = localRecords[i];
            }
        }
        else
        {
            usgData = new USGData();
            usgData.records[0] = (int)WinData.score;
        }

        string saveJson = JsonUtility.ToJson(usgData, true);
        File.WriteAllText(filePath, saveJson);

        for (int i = 0; i < 5; i++)
        {
            Debug.Log($"Record {i + 1}: Score {usgData.records[i]}");
        }
    }
}
