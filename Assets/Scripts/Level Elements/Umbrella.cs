using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Umbrella : MonoBehaviour
{
	[SerializeField] private float gravityScale = 0.2f;
	[SerializeField] private float drag = 0.5f;
	[SerializeField] private float destroyDelay = 10;

	private new Rigidbody2D rigidbody;
	private bool isPlayerMounted;
	private bool isDropped;
	private Transform playerTransform;
	private Rigidbody2D playerRigidbody;
	private PlayerController playerController;

	private Vector3 grabOffset;
	private float oldGravityScale;
	private float oldDrag;

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
			transform.position = playerRigidbody.transform.position + grabOffset;

			if (playerController.IsGrounded)
				DetachPlayer();
		}
	}


	private void AttachPlayer(Collider2D player)
	{
		playerTransform = player.transform;
		playerRigidbody = player.attachedRigidbody;
		playerController = player.GetComponent<PlayerController>();
		isPlayerMounted = true;

		oldGravityScale = playerRigidbody.gravityScale;
		oldDrag = playerRigidbody.drag;
		playerRigidbody.gravityScale = gravityScale;
		playerRigidbody.drag = drag;

		grabOffset = transform.position - playerTransform.position;
		rigidbody.isKinematic = true;
	}

	private void DetachPlayer()
	{
		playerRigidbody.gravityScale = oldGravityScale;
		playerRigidbody.drag = oldDrag;
		isPlayerMounted = false;
		isDropped = true;

		rigidbody.velocity = playerRigidbody.velocity;
		rigidbody.isKinematic = false;
		Destroy(gameObject, destroyDelay);
	}
}