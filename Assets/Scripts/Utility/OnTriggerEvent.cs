using System;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEvent : MonoBehaviour
{
	[SerializeField] private bool onlyTriggerOnce = false;
	[SerializeField] private UnityEvent onTriggerEnter = null;

	private bool hasTriggered;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (onlyTriggerOnce && hasTriggered) return;

		onTriggerEnter.Invoke();
		hasTriggered = true;
	}
}