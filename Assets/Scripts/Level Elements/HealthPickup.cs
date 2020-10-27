using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HealthPickup : MonoBehaviour
{
	[SerializeField] private int healthValue = 5;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Player player = other.GetComponent<Player>();
			if (player != null)
			{
				player.Health += healthValue;
				Destroy(gameObject);
			}
		}
	}
}