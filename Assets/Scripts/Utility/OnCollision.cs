using System;
using UnityEngine;
using UnityEngine.Events;

public class OnCollision : MonoBehaviour
{
	[SerializeField] private bool oneShot = false;
	[SerializeField] private LayerMask layerMask = -1;
	[SerializeField] private string targetTag = null;
	[SerializeField] private UnityEvent onCollision = null;

	private bool hasActivated;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (oneShot && hasActivated) return;
		if (((1 << collision.gameObject.layer) & layerMask.value) == 0) return;
		if (targetTag != "" && !collision.gameObject.CompareTag(targetTag)) return;

		onCollision.Invoke();
		hasActivated = true;
	}
}