using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class WinData : MonoBehaviour
{
    public static float score;
    public static int stars;
    public static float time;
    private void Awake() 
    {
        score = 0f;
        stars = 0;
        time = 0f;
    }

    private void Start()
    {
        score = GameData.playerHealth;
        stars = Mathf.CeilToInt(score/20);
        time = GameData.time;

        Debug.Log("Score: " + score);
        Debug.Log("Stars: " + stars);
        Debug.Log("Time: " + time);
    }
}
