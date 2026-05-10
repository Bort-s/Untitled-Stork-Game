using System.Diagnostics;
using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class WallCloudDamage : MonoBehaviour
{
    private bool interCooldown = false;
    private float interCooldownTime = 0.1f;
    private void OnTriggerStay2D(Collider2D other)
    {
        if(GameData.playerCanTakeDamage && !interCooldown)
        {
           if (other.CompareTag("Player"))
            {
                interCooldown = true;
                StartCoroutine(takeDamage());
            }
        }
    }

    private IEnumerator takeDamage()
    {
        GameData.playerHealth -= 1f;
        yield return new WaitForSeconds(interCooldownTime);
        interCooldown = false;
    }
}


