using UnityEngine;
using DG.Tweening;
using System.Collections;

public class CloudDamage : MonoBehaviour
{
    private SpriteRenderer sprite;
    private bool cloudDestroyed = false;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!cloudDestroyed)
        {
            if (collision.CompareTag("Player") && collision is PolygonCollider2D)
            {
                if (GameData.playerCanTakeDamage && !GameData.onShield)
                {
                    GameData.playerHealth -= GameDifficulty.cloudHitDamage;
                    GameData.launchCloudCooldown = true;

                    cloudDestroyed = true;
                    DestroyCloud();
                }
                else if (GameData.onShield)
                {
                    cloudDestroyed = true;
                    DestroyCloud();
                }
            }
        }
    }

    private void DestroyCloud()
    {
        float fadeTime = 1f / GameData.speed;
        if (sprite != null)
            sprite.DOFade(0f, fadeTime).OnComplete(() => Destroy(gameObject));
    }
}
