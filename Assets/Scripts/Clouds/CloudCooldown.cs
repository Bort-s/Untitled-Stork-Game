using UnityEngine;
using System.Collections;
using Debug = UnityEngine.Debug;

public class CloudCooldown : MonoBehaviour
{
    private float cooldownTime = 3f;
    void Update()
    {
        if (GameData.onCooldown && GameData.playerCanTakeDamage)
        {
            GameData.playerHealth -= 7f;
            GameData.playerCanTakeDamage = false;
            StartCoroutine(CooldownTime());
        }
    }

    private IEnumerator CooldownTime()
    {
        Debug.Log("Damage Cooldown active");
        yield return new WaitForSeconds(cooldownTime);
        if (!GameData.onShield)
            GameData.playerCanTakeDamage = true;
        GameData.onCooldown = false;
        Debug.Log("Damage Cooldown finished");
    }
}
