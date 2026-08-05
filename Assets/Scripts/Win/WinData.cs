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
        score = GameData.playerHealth;
        stars = Mathf.CeilToInt(score/20);
        time = GameData.time;
    }

    private void Start()
    {
        Debug.Log("Score: " + score);
        Debug.Log("Stars: " + stars);
        Debug.Log("Time: " + time);
    }
}
