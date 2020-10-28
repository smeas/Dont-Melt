using System;
using UnityEngine;

public class ImpactDamager : MonoBehaviour
{
	[SerializeField] private float damage = 10;

	[SerializeField, Tooltip("The minimum amount of impact velocity required to damage the player.")]
	private float minImpactVelocity = 6;

	private new Rigidbody2D rigidbody;
	private Vector2 previousVelocity;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		previousVelocity = rigidbody.velocity;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (previousVelocity.sqrMagnitude >= minImpactVelocity * minImpactVelocity &&
			collision.collider.CompareTag("Player"))
		{
			Player player = collision.collider.GetComponent<Player>();
			player.TakeDamage(damage);
		}
	}
}