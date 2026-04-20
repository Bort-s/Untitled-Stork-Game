using UnityEngine;
using DG.Tweening;
using System.Collections;

public class CloudDamage : MonoBehaviour
{
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

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
        float fadeTime = 1f / GameData.speed;
        if (sprite != null)
            sprite.DOFade(0f, fadeTime).OnComplete(() => Destroy(gameObject));
    }
}
