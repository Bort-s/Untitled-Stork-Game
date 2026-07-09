using UnityEngine;
using System.Collections;
using Debug = UnityEngine.Debug;

public class playerHealth : MonoBehaviour
{
    // Health
    private float timeToDecrease = 5f;
    private bool onCoroutine = false;

    private bool deadMessage = false;

    void Update()
    {
        if (GameData.playerHealth <= 0f && !GameData.gameCompleted)
        {
            GameData.isDead = true;
            GameData.playerCanTakeDamage = false;
            if (!deadMessage)
            {
                Debug.Log("Player has died.");
                deadMessage = true;
            }
        }

        if (!onCoroutine)
        {
            StartCoroutine(TimeDamage());
        }
    }

    private IEnumerator TimeDamage()
    {
        onCoroutine = true;
        if (GameData.playerCanTakeDamage)
        {
            GameData.playerHealth -= 1f;
            Debug.Log("New Player Health: " + GameData.playerHealth);
        }
        yield return new WaitForSeconds(timeToDecrease);
        onCoroutine = false;
    }
}
