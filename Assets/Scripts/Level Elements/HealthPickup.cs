using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class HealthPickup : MonoBehaviour
{
	[SerializeField] private int healthValue = 5;
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private UnityEvent onPickup = null;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Player player = other.GetComponent<Player>();
			if (player != null)
			{
				player.Heal(healthValue);
				PlaySound();
				onPickup.Invoke();
				Destroy(gameObject);
			}
		}
	}

	private void PlaySound()
	{
		audioSource.Play();
		audioSource.transform.parent = null;
		Destroy(audioSource.gameObject, audioSource.clip.length);
	}
}