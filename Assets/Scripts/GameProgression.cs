using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Diagnostics;
using System.Collections;
public class GameProgression : MonoBehaviour
{
    private bool gameCompletedMessage = false;
    private bool onCoroutine = false;

    void Update()
    {
        if (GameData.gameProgress < GameDifficulty.maxGameProgress && !onCoroutine && !GameData.isDead)
        {
            StartCoroutine(Progression());
            onCoroutine = true;
        }
        else if (GameData.gameProgress >= GameDifficulty.maxGameProgress)
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
        Debug.Log("Game Progress: " + GameData.gameProgress);
        yield return new WaitForSeconds(1f);
        onCoroutine = false;
    }
}
