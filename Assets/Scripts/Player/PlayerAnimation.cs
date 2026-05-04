using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.speed = (0.175f * GameData.speed) + 0.625f;
    }
}