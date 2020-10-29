using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float speed = 500;
	[SerializeField] private float jumpForce = 7;
	[SerializeField] private float speedScale = 1;
	[SerializeField, Tooltip("Limit the velocity of the rigidbody. Set to 0 for no limit.")]
	private Vector2 maxVelocity = new Vector2(10, 10);

	[Header("Collision")]
	[SerializeField] private new Collider2D collider = null;
	[SerializeField] private Collider2D groundCollider = null;
	[SerializeField] private LayerMask groundLayer = default;
	[SerializeField] private LayerMask waterLayer = default;

	[Header("Events")]
	[SerializeField] private UnityEvent onJump = null;
	[SerializeField] private float minImpactPowerToRegister = 1;
	[SerializeField] private UnityEvent onImpact = null;

	private new Rigidbody2D rigidbody;
	private bool jump;
	private float move;
	private bool isGrounded;
	private bool isUnderwater;
	private Vector2 groundNormal = Vector2.up;

	public float SpeedScale
	{
		get => speedScale;
		set => speedScale = value;
	}

	public bool IsGrounded => isGrounded;

	public bool IsUnderwater => isUnderwater;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");
		move += horizontal * speed * Time.deltaTime;

		if (isGrounded || isUnderwater)
		{
			if (Input.GetButtonDown("Jump"))
				jump = true;
		}

		if (isGrounded) UpdateGroundNormal();
	}

	private void FixedUpdate()
	{
		Vector2 groundRight = -Vector2.Perpendicular(groundNormal); // rotate the ground normal 90 degrees clockwise
		rigidbody.AddForce(groundRight * new Vector2(move, 0) * (rigidbody.mass * speedScale));
		move = 0;

		if (jump)
		{
			rigidbody.AddForce(Vector2.up * (jumpForce * rigidbody.mass * speedScale), ForceMode2D.Impulse);
			jump = false;
			onJump.Invoke();
		}

		isGrounded = groundCollider.IsTouchingLayers(groundLayer);
		isUnderwater = collider.IsTouchingLayers(waterLayer);

		LimitMaxSpeed();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Vector2 averageImpactNormal = new Vector2();
		for (int i = 0; i < collision.contactCount; i++)
			averageImpactNormal += collision.GetContact(i).normal;
		averageImpactNormal /= collision.contactCount;

		// If we didn't slow down in the direction of the collision it's not an impact.
		if (Vector2.Dot(rigidbody.velocity, -averageImpactNormal) >= 0.1f)
			return;

		// The impact power is the relative velocity in the direction of the impact normal.
		float impactPower = Mathf.Abs(Vector2.Dot(collision.relativeVelocity, averageImpactNormal));
		if (impactPower >= minImpactPowerToRegister)
			onImpact.Invoke();
	}


	private void UpdateGroundNormal()
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 10, groundLayer);
		if (hit.collider != null)
		{
			groundNormal = hit.normal;
		}
	}

	private void LimitMaxSpeed()
	{
		Vector2 currentVelocity = rigidbody.velocity;
		if (maxVelocity.x > 0) currentVelocity.x = Mathf.Clamp(currentVelocity.x, -maxVelocity.x, maxVelocity.x);
		if (maxVelocity.y > 0) currentVelocity.y = Mathf.Clamp(currentVelocity.y, -maxVelocity.y, maxVelocity.y);
		rigidbody.velocity = currentVelocity;
	}
}