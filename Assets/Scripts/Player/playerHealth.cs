using UnityEngine;
using System.Collections;
using Debug = UnityEngine.Debug;

public class playerHealth : MonoBehaviour
{
    // Health
    private float timeToDecrease;
    private float startTime;

    private bool onCoroutine = false;
    private bool deadMessage = false;

    void Start()
    {
        startTime = Time.time;
    }

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
            timeToDecrease = GetTimeToDecrease(Time.time - startTime);
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

    private float GetTimeToDecrease(float time)
    {
        return Mathf.Round((-0.025f * time) + 6.5f);
    }
}
