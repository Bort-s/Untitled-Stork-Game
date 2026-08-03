using UnityEngine;
using System.Collections;
using Debug = UnityEngine.Debug;

public class CloudCooldown : MonoBehaviour
{
    void Update()
    {
        if (GameData.launchCloudCooldown)
        {
            GameData.launchCloudCooldown = false;
            GameData.onCloudCooldown = true;
            StartCoroutine(CooldownTime());
        }

        if (GameData.onCloudCooldown)
        {
            GameData.playerCanTakeDamage = false;
        }

        if (GameData.onShield)
        {
            GameData.onCloudCooldown = false;
        }
    }

    private IEnumerator CooldownTime()
    {
        Debug.Log("Damage Cooldown active");
        yield return new WaitForSeconds(GameDifficulty.cloudHitCooldown);
        if (!GameData.onShield)
            GameData.playerCanTakeDamage = true;
        Debug.Log("Damage Cooldown finished");
        GameData.onCloudCooldown = false;
    }
}
