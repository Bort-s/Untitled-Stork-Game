using UnityEngine;
using System.Collections;

public class PlayerOnCooldown : MonoBehaviour
{
    private SpriteRenderer sprite;

    private double colorDuration = 0.25;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (GameData.launchCloudCooldown)
        {
            StartCoroutine(PlayerCooldown());
        }

        if (GameData.onShield)
        {
            sprite.color = Color.white;
        }
    }

    private IEnumerator PlayerCooldown()
    {
        for (int i = 1; i <= (GameDifficulty.cloudHitCooldown / colorDuration); i++)
        {
            if (i % 2 == 1)
            {
                if (GameData.onShield)
                {
                    sprite.color = Color.white;
                }
                else
                {
                    sprite.color = new Color(1f, 0.749f, 0.749f);
                }
            }
            else
            {
                sprite.color = Color.white;
            }
            yield return new WaitForSeconds((float)colorDuration);
        }

        sprite.color = Color.white;
    }
}
