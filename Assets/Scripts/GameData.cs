using System.Diagnostics;
using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;


public class GameData : MonoBehaviour
{
    public static float playerHealth = 100f;
    public static bool isDead = false;
    public static float speed = 1f;
    public static bool cooldown = false;
    public static bool onCooldown = false;
    public static float gameProgress = 0f;
    public static bool gameCompleted = false;
    public static float maxGameProgress = 100f;

    
    private bool onCoroutine = false;
    


    private void Awake()
    {
        playerHealth = 100f;
        isDead = false;
        speed = 1f;
        cooldown = false;
        onCooldown = false;
        gameProgress = 0f;
    }


    private void Update()
    {
        if (onCooldown)
        {
            onCooldown = false;
            Debug.Log("Cooldown active");
            StartCoroutine(CooldownTime());
        }

        if (playerHealth <= 0f)
        {
            isDead = true;
            Debug.Log("Player has died.");
        }

        if (gameProgress < maxGameProgress && !onCoroutine)
        {
            StartCoroutine(GameProgression());
            onCoroutine = true;
        } else if (gameProgress >= maxGameProgress)
        {
            gameCompleted = true;
            Debug.Log("Game Completed!");
        }
    }

    private IEnumerator CooldownTime()
    {
        yield return new WaitForSeconds(1.5f);
        cooldown = false;
        Debug.Log("Cooldown finished");
    }

    private IEnumerator GameProgression()
    {
        gameProgress += speed;
        Debug.Log("Game Progress: " + gameProgress);
        yield return new WaitForSeconds(1f);
        onCoroutine = false;
    }
}
