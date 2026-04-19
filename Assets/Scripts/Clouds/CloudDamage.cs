using UnityEngine;
using System.Collections;

public class CloudDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!GameData.cooldown)
        {
           if (other.CompareTag("Player"))
            {
                GameData.playerHealth -= 10f;
                GameData.cooldown = true;
                GameData.onCooldown = true;
            }
            DestroyCloud();
        }
    }

    private void DestroyCloud()
    {
        Destroy(gameObject);
    }
}
