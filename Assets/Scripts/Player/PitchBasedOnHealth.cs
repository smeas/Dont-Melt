using System;
using UnityEngine;

// Jonatan
public class PitchBasedOnHealth : MonoBehaviour {
	[SerializeField] private Player player = null;

	[SerializeField, Range(0, 2)]
	private float fullPitch = 1;

	[SerializeField, Range(0, 2)]
	private float emptyPitch = 1.6f;

	private AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void Update()
	{
		audioSource.pitch = Mathf.Lerp(emptyPitch, fullPitch, player.HealthFraction);
	}
}
