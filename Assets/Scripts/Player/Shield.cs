using UnityEngine;
using System.Collections;
using Debug = UnityEngine.Debug;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.InputSystem;

public class Shield : MonoBehaviour
{

    void Update()
    {
        if (Keyboard.current.eKey.isPressed && !GameData.isDead && !GameData.gameCompleted && !GameData.onShield && !GameData.onShieldCooldown)
        {
            StartCoroutine(ShieldActivated());
        }
    }

    private IEnumerator ShieldActivated()
    {
        Debug.Log("Shield on");
        GameData.onShield = true;
        GameData.playerCanTakeDamage = false;

        yield return new WaitForSeconds(GameDifficulty.shieldDuration);
        
        GameData.onShield = false;
        if (!GameData.isDead && !GameData.gameCompleted)
            GameData.playerCanTakeDamage = true;
        Debug.Log("Shield off, initiating cooldown...");
        StartCoroutine(ShieldCooldown());
    }

    private IEnumerator ShieldCooldown()
    {
        GameData.onShieldCooldown = true;
        yield return new WaitForSeconds(GameDifficulty.shieldCooldown);
        GameData.onShieldCooldown = false;
        Debug.Log("Shield Cooldown terminated");
    }
}
