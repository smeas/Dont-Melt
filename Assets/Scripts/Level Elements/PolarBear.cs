using System;
using UnityEngine;

// Jonatan
public class PolarBear : MonoBehaviour
{
	[SerializeField] private Vector2 speed;

	private void Update()
	{
		transform.position += (Vector3)(speed * Time.deltaTime);
	}
}