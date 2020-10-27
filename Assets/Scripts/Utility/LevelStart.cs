using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    [SerializeField] private string animation = "SnowFadeOut";
    [SerializeField] private Animator animator;
    void Start()
    {
        if (animator == null)
            Debug.LogError("Missing animation.");

        animator.Play(animation);
        Destroy(this);
    }
}
