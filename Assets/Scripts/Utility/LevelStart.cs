using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Robin
public class LevelStart : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private float particleStartTime = 1f;
    [SerializeField] private readonly string animation = "SnowFadeOut";
    [SerializeField] private Animator animator;
    void Start()
    {
        if (animator == null && particle == null)
            Debug.LogError("Missing something.");

        animator.Play(animation);
        particle.Simulate(particleStartTime);
        particle.Play();
        Destroy(this);
    }
}
