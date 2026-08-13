using UnityEngine;
using System.IO;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private SetScore setScore;
    [SerializeField] private int scoreNumber;
    private USGData usgData;
    private string filePath;

    private void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "save_data.json");
    }

    void Start()
    {
        if (setScore != null && scoreNumber != 0f)
        {
            if (File.Exists(filePath))
            {
                string loadJson = File.ReadAllText(filePath);
                usgData = JsonUtility.FromJson<USGData>(loadJson);

                if (usgData == null || usgData.records == null || usgData.records.Length != 5)
                {
                    usgData = new USGData();
                }
            }
            else
            {
                usgData = new USGData();
            }

            setScore.PutScore(usgData.records[scoreNumber - 1]);
        }
    }
}
