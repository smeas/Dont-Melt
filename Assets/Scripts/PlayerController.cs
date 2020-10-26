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

	private void Start()
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

			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 10, groundLayer);
			if (hit.collider != null)
			{
				groundNormal = hit.normal;
			}
		}
	}

	private void FixedUpdate()
	{
		Vector2 groundRight = Quaternion.Euler(0, 0, -90) * groundNormal;
		rigidbody.AddForce(groundRight * new Vector2(move, 0));
		move = 0;

		if (jump)
		{
			rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			jump = false;
		}

		isGrounded = groundCollider.IsTouchingLayers(groundLayer);
	}

	// DEBUG
	// private void OnDrawGizmos()
	// {
	// 	Vector3 right = Quaternion.Euler(0, 0, -90) * surfaceNormal;
	// 	Debug.DrawRay(transform.position, right);
	// }
}