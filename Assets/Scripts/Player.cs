using System;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private int health = 100;
	[SerializeField] private int maxHealth = 100;

	[Header("Scale")]
	[SerializeField] private float minScale = 0.2f;
	[SerializeField] private float maxScale = 1f;
	[SerializeField] private float minSpeedScale = 1f;
	[SerializeField] private float maxSpeedScale = 1.2f;

	private PlayerController controller;

	public int Health
	{
		get => health;
		set
		{
			health = Mathf.Clamp(value, 0, maxHealth);
			UpdatePlayerSize();
		}
	}

	public int MaxHealth => maxHealth;

	/// <summary>
	/// A value between zero and one (inclusive) representing the percentage of health left.
	/// </summary>
	public float HealthFraction => (float)Health / MaxHealth;

	private void Start()
	{
		controller = GetComponent<PlayerController>();
		UpdatePlayerSize();
	}

	private void OnValidate()
	{
		UpdatePlayerSize();
	}

	private void UpdatePlayerSize()
	{
		float scale = Mathf.Lerp(minScale, maxScale, HealthFraction);
		transform.localScale = new Vector3(scale, scale, scale);

		if (controller != null)
			controller.SpeedScale = Mathf.Lerp(maxSpeedScale, minSpeedScale, HealthFraction);
	}
}