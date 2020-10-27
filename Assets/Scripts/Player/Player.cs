using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	[SerializeField] private float health = 100;
	[SerializeField] private float maxHealth = 100;

	[Header("Scale")]
	[SerializeField] private float minScale = 0.2f;
	[SerializeField] private float maxScale = 1f;
	[SerializeField] private float minSpeedScale = 1f;
	[SerializeField] private float maxSpeedScale = 1.2f;

	[Header("Events")]
	[SerializeField] private UnityEvent onTakeDamage = null;
	[SerializeField] private UnityEvent onDie = null;

	private PlayerController controller;

	public float Health
	{
		get => health;
		set
		{
			health = Mathf.Clamp(value, 0, maxHealth);
			UpdatePlayerSize();
		}
	}

	public float MaxHealth => maxHealth;

	/// <summary>
	/// A value between zero and one (inclusive) representing the percentage of health left.
	/// </summary>
	public float HealthFraction => Health / MaxHealth;

	private void Start()
	{
		controller = GetComponent<PlayerController>();
		UpdatePlayerSize();
	}

	private void OnValidate()
	{
		UpdatePlayerSize();
	}

	public void Heal(float amount)
	{
		Health += amount;
	}

	public void TakeDamage(float amount)
	{
		float newHealth = Mathf.Clamp(health - amount, 0, maxHealth);
		if (health != newHealth)
		{
			health = newHealth;
			UpdatePlayerSize();
			onTakeDamage.Invoke();

			if (health <= 0)
			{
				onDie.Invoke();
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}

	private void UpdatePlayerSize()
	{
		float scale = Mathf.Lerp(minScale, maxScale, HealthFraction);
		transform.localScale = new Vector3(scale, scale, scale);

		if (controller != null)
			controller.SpeedScale = Mathf.Lerp(maxSpeedScale, minSpeedScale, HealthFraction);
	}
}