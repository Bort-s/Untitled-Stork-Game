using UnityEngine;



public class GameData : MonoBehaviour
{
    // General
    public static float speed;
    public static bool onCloudCooldown;

    // Shield
    public static bool onShield;
    public static bool onShieldCooldown;

    // Health
    public static float playerHealth;
    public static bool isDead;
    public static bool playerCanTakeDamage;

    // Game Progression
    public static float gameProgress;
    public static bool gameCompleted;
}
