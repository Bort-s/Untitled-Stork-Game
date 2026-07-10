using System.Diagnostics;
using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class WallCloudDamage : MonoBehaviour
{
    private bool interCooldown = false;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (GameData.playerCanTakeDamage && !interCooldown && other.CompareTag("Player"))
        {
            interCooldown = true;
            StartCoroutine(takeDamage());
        }
    }

    private IEnumerator takeDamage()
    {
        GameData.playerHealth -= 1f;
        Debug.Log("New Player Health: " + GameData.playerHealth);
        yield return new WaitForSeconds(GameDifficulty.wallCloudHitCooldown);
        interCooldown = false;
    }
}


