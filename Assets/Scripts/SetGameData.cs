using UnityEngine;

public class SetGameData : MonoBehaviour
{
    private void Awake()
    {
        GameData.speed = 1f;
        GameData.launchWall = false;
        GameData.time = 0f;

        GameData.onCloudCooldown = false;
        GameData.launchCloudCooldown = false;

        GameData.onShield = false;
        GameData.onShieldCooldown = false;

        GameData.playerHealth = 100f;
        GameData.isDead = false;
        GameData.playerCanTakeDamage = true;

        GameData.gameProgress = 0f;
        GameData.gameCompleted = false;
    }
}
