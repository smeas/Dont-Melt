using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Umbrella : MonoBehaviour
{
	[SerializeField] private float gravityScale = 0.2f;
	[SerializeField] private float destroyDelay = 10;

	private new Rigidbody2D rigidbody;
	private bool isPlayerMounted;
	private bool isDropped;
	private Rigidbody2D playerRigidbody;
	private PlayerController playerController;
	private float oldGravityScale;

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		rigidbody.isKinematic = true;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (isPlayerMounted || isDropped) return;
		if (other.CompareTag("Player"))
			AttachPlayer(other);
	}

	private void Update()
	{
		if (isPlayerMounted)
		{
			//transform.position = playerRigidbody.position;

			if (playerController.IsGrounded)
				DetachPlayer();
		}
	}


	private void AttachPlayer(Collider2D player)
	{
		playerRigidbody = player.GetComponent<Rigidbody2D>();
		playerController = player.GetComponent<PlayerController>();
		isPlayerMounted = true;

		oldGravityScale = playerRigidbody.gravityScale;
		playerRigidbody.gravityScale = gravityScale;

		transform.parent = playerRigidbody.transform;
		rigidbody.isKinematic = true;
	}

	private void DetachPlayer()
	{
		playerRigidbody.gravityScale = oldGravityScale;
		playerRigidbody = null;
		playerController = null;
		isPlayerMounted = false;
		isDropped = true;

		transform.parent = null;
		rigidbody.isKinematic = false;
		Destroy(gameObject, destroyDelay);
	}
}