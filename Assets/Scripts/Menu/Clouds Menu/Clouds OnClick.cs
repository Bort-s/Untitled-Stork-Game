using UnityEngine;
using DG.Tweening;
using System.Collections;

public class CloudsOnClick : MonoBehaviour
{
    public float fadeTime = 1f;

    private bool isDestroyed = false;

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnMouseUpAsButton()
    {
        if (!isDestroyed)
        {
            isDestroyed = true;
            if (sprite != null)
                sprite.DOFade(0f, fadeTime).OnComplete(() => Destroy(gameObject));
        }
    }

    private void OnBecameInvisible()
    {
        if (!isDestroyed)
        {
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
