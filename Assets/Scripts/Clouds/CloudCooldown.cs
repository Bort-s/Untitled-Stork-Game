using UnityEngine;
using System.Collections;
using Debug = UnityEngine.Debug;

public class CloudCooldown : MonoBehaviour
{
    void Update()
    {
        if (GameData.onCloudCooldown && GameData.playerCanTakeDamage && !GameData.onShield)
        {
            GameData.playerHealth -= GameDifficulty.cloudHitDamage;
            GameData.playerCanTakeDamage = false;
            GameData.onCloudCooldown = false;
            StartCoroutine(CooldownTime());
        }
    }

    private IEnumerator CooldownTime()
    {
        Debug.Log("Damage Cooldown active");
        yield return new WaitForSeconds(GameDifficulty.cloudHitCooldown);
        if (!GameData.onShield)
            GameData.playerCanTakeDamage = true;
        Debug.Log("Damage Cooldown finished");
    }
}
