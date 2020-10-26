using System;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private int health = 100;
	[SerializeField] private int maxHealth = 100;
	[SerializeField] private float minScale = 0.2f;
	[SerializeField] private float maxScale = 1f;

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

	private void Start()
	{
		UpdatePlayerSize();
	}

	private void OnValidate()
	{
		UpdatePlayerSize();
	}

	private void UpdatePlayerSize()
	{
		float scale = Mathf.Lerp(minScale, maxScale, (float)health / maxHealth);
		transform.localScale = new Vector3(scale, scale, scale);
	}
}