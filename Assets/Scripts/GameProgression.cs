using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Diagnostics;
using System.Collections;
public class GameProgression : MonoBehaviour
{
    private bool gameCompletedMessage = false;
    public static float maxGameProgress = 100f;
    private bool onCoroutine = false;
    float C = 1f;

    void Update()
    {
        if (GameData.gameProgress < maxGameProgress && !onCoroutine && !GameData.isDead)
        {
            StartCoroutine(Progression());
            if (GameData.gameProgress > 10f * C)
            {
                Debug.Log("Game Progress: " + GameData.gameProgress);
                C += 10f;
            }
            onCoroutine = true;
        }
        else if (GameData.gameProgress >= maxGameProgress)
        {
            GameData.gameCompleted = true;
            GameData.playerCanTakeDamage = false;
            if (!gameCompletedMessage)
            {
                Debug.Log("Game Completed!");
                gameCompletedMessage = true;
            }
        }
    }

    private IEnumerator Progression()
    {
        GameData.gameProgress += GameData.speed;
        yield return new WaitForSeconds(1f);
        onCoroutine = false;
    }
}
