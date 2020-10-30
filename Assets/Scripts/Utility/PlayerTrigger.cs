using System;
using UnityEngine;
using UnityEngine.Events;

// Jonatan
public class PlayerTrigger : MonoBehaviour
{
	[SerializeField] private bool onlyTriggerOnce = false;
	[SerializeField] private UnityEvent onTriggerEnter = null;

	private bool hasTriggered;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (onlyTriggerOnce && hasTriggered) return;
		if (other.CompareTag("Player"))
		{
			onTriggerEnter.Invoke();
			hasTriggered = true;
		}
	}
}