using UnityEngine;

public class SetWinData : MonoBehaviour
{
    [SerializeField] private SetScore setScore;
    [SerializeField] private SetTime setTime;
    void Start()
    {
        if (setTime != null)
        {
            int gameTime = (int)WinData.time;
            setTime.PutTime(gameTime);
        }
        else
        {
            int gameScore = (int)WinData.score;
            setScore.PutScore(gameScore);
        }
    }
}
