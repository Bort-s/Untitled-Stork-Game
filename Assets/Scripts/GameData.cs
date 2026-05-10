using System.Diagnostics;
using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;


public class GameData : MonoBehaviour
{
    // Health
    public static float playerHealth = 100f;
    public static bool isDead = false;
    public static float speed = 1f;
    public static bool playerCanTakeDamage = true;

    // Cooldowns
    public static bool damageCooldown = false;

    // Game Progression
    public static float gameProgress = 0f;
    public static bool gameCompleted = false;
    public static float maxGameProgress = 100f;
    float C = 1f;

    // Else..
    private bool onCoroutine = false;


    // Debugging
    private bool deadMessage = false;
    private bool gameCompletedMessage = false;
    


    private void Awake()
    {
        playerHealth = 100f;
        isDead = false;
        speed = 1f;
        damageCooldown = false;
        gameProgress = 0f;
        gameCompleted = false;
        onCoroutine = false;
        deadMessage = false;
        gameCompletedMessage = false;
        playerCanTakeDamage = true;
    }


    private void Update()
    {
        if (damageCooldown && playerCanTakeDamage)
        {
            damageCooldown = false;
            playerCanTakeDamage = false;
            Debug.Log("Damage Cooldown active");
            StartCoroutine(CooldownTime());
        }

        if (playerHealth <= 0f)
        {
            isDead = true;
            if (!deadMessage)
            {
                Debug.Log("Player has died.");
                deadMessage = true;
            }
        }

        if (gameProgress < maxGameProgress && !onCoroutine)
        {
            StartCoroutine(GameProgression());
            if (gameProgress > 10f * C)
            {
            Debug.Log("Game Progress: " + gameProgress);
                C += 10f;
            }
            onCoroutine = true;
        } 
        else if (gameProgress >= maxGameProgress)
        {
            gameCompleted = true;
            if (!gameCompletedMessage)
            {
                Debug.Log("Game Completed!");
                gameCompletedMessage = true;
            }
        }
    }

    private IEnumerator CooldownTime()
    {
        yield return new WaitForSeconds(1.5f);
        damageCooldown = false;
        playerCanTakeDamage = true;
        Debug.Log("Damage Cooldown finished");
    }

    private IEnumerator GameProgression()
    {
        gameProgress += speed;
        yield return new WaitForSeconds(1f);
        onCoroutine = false;
    }
}
