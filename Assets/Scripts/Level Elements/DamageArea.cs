using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DamageArea : MonoBehaviour
{
	private enum DamageMode
	{
		Single,
		Continuous,
	}

	[SerializeField] private DamageMode mode = DamageMode.Single;
	[SerializeField] private float damage = 10;

	private void OnTriggerEnter2D(Collider2D other) => OnEnter(other);
	private void OnCollisionEnter2D(Collision2D collision) => OnEnter(collision.collider);
	private void OnTriggerStay2D(Collider2D other) => OnStay(other);
	private void OnCollisionStay2D(Collision2D collision) => OnStay(collision.collider);

	private void OnEnter(Collider2D other)
	{
		if (mode != DamageMode.Single) return;

		Player player = GetPlayer(other);
		if (player != null)
			player.TakeDamage(damage);
	}

	private void OnStay(Collider2D other)
	{
		if (mode != DamageMode.Continuous) return;

		Player player = GetPlayer(other);
		if (player != null)
			player.TakeDamage(damage * Time.deltaTime);
	}

	private static Player GetPlayer(Collider2D other)
	{
		return other.CompareTag("Player") ? other.GetComponent<Player>() : null;
	}
}