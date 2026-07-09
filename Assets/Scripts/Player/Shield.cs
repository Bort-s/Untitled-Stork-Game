using UnityEngine;
using System.Collections;
using Debug = UnityEngine.Debug;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.InputSystem;

public class Shield : MonoBehaviour
{
    private bool onCooldown = false;
    private float shieldCooldown = 5f;
    private float shieldDuration = 3f;

    void Update()
    {
        if (Keyboard.current.eKey.isPressed && !GameData.isDead && !GameData.gameCompleted && !GameData.onShield && !onCooldown)
        {
            StartCoroutine(ShieldActivated());
        }
    }

    private IEnumerator ShieldActivated()
    {
        Debug.Log("Shield on");
        GameData.onShield = true;
        GameData.playerCanTakeDamage = false;
        yield return new WaitForSeconds(shieldDuration);
        GameData.onShield = false;
        if (!GameData.isDead && !GameData.gameCompleted)
            GameData.playerCanTakeDamage = true;
        Debug.Log("Shield off, initiating cooldown...");
        StartCoroutine(ShieldCooldown());
    }

    private IEnumerator ShieldCooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(shieldCooldown);
        onCooldown = false;
        Debug.Log("Shield Cooldown terminated");
    }
}
