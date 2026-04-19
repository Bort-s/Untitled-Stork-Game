using System.Diagnostics;
using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;


public class GameData : MonoBehaviour
{
    public static float playerHealth = 100f;
    public static float speed = 1f;
    public static bool cooldown = false;
    public static bool onCooldown = false;

    private void Update()
    {
        if (onCooldown)
        {
            onCooldown = false;
            Debug.Log("Cooldown active");
            StartCoroutine(CooldownTime());
        }
    }

    private IEnumerator CooldownTime()
    {
        yield return new WaitForSeconds(1.5f);
        cooldown = false;
        Debug.Log("Cooldown finished");
    }
}
