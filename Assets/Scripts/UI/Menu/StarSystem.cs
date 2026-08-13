using UnityEngine;
using System.IO;

public class StarSystem : MonoBehaviour
{
    [SerializeField] private Sprite star;

    [SerializeField] private SpriteRenderer[] star1;
    [SerializeField] private SpriteRenderer[] star2;
    [SerializeField] private SpriteRenderer[] star3;
    [SerializeField] private SpriteRenderer[] star4;
    [SerializeField] private SpriteRenderer[] star5;

    private string filePath;
    private USGData usgData;

    private void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "save_data.json");
    }

    private void Start()
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

        SpriteRenderer[][] allStars = new SpriteRenderer[][]
        {
            star1,
            star2,
            star3,
            star4,
            star5
        };

        for (int i = 0; i < 5; i++)
        {
            float record = usgData.records[i];
            int stars = Mathf.CeilToInt(record / 20);

            Debug.Log($"Record {i + 1}: Score {usgData.records[i]}, Stars {stars}");

            for (int j = 0; j < 5; j++)
            {
                if (j < stars)
                {
                    allStars[i][j].sprite = star;
                }
            }
        }
    }
}
