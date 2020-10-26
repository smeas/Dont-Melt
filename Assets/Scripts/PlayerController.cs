using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float speed = 500;
	[SerializeField] private float jumpForce = 7;
	[SerializeField] private Collider2D groundCollider = null;
	[SerializeField] private LayerMask groundLayer = default;

	private new Rigidbody2D rigidbody;
	private bool jump;
	private float move;
	private bool isGrounded;
	private Vector2 groundNormal = Vector2.up;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");
		move += horizontal * speed * Time.deltaTime;

		if (isGrounded)
		{
			if (Input.GetButtonDown("Jump"))
				jump = true;

			UpdateGroundNormal();
		}
	}

	private void FixedUpdate()
	{
		Vector2 groundRight = -Vector2.Perpendicular(groundNormal); // rotate the ground normal 90 degrees clockwise
		rigidbody.AddForce(groundRight * new Vector2(move, 0) * rigidbody.mass);
		move = 0;

		if (jump)
		{
			rigidbody.AddForce(jumpForce * rigidbody.mass * Vector2.up, ForceMode2D.Impulse);
			jump = false;
		}

		isGrounded = groundCollider.IsTouchingLayers(groundLayer);
	}

	private void UpdateGroundNormal()
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 10, groundLayer);
		if (hit.collider != null)
		{
			groundNormal = hit.normal;
		}
	}

	// DEBUG
	// private void OnDrawGizmos()
	// {
	// 	Vector3 right = -Vector2.Perpendicular(groundNormal);
	// 	Debug.DrawRay(transform.position, right);
	// }
}