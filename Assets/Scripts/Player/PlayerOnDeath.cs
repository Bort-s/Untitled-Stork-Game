using UnityEngine;
using System.Collections;

public class PlayerOnDeath : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private bool OnDeathActivated = false;

    void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (GameData.isDead && !OnDeathActivated)
        {
            StartCoroutine(OnDeath());
        }
    }

    private IEnumerator OnDeath()
    {
        OnDeathActivated = true;
        boxCollider2D.isTrigger = true;
        yield return null;
    }
}
