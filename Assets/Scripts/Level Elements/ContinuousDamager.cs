using UnityEngine;

// Jonatan
public class ContinuousDamager : MonoBehaviour
{
	[SerializeField] private float damagePerSecond = 1;

	private Player player;

	private void OnEnable()
	{
		if (player == null)
		{
			GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
			if (playerObject != null)
				player = playerObject.GetComponent<Player>();
		}
	}

	private void Update()
	{
		if (player != null)
			player.TakeDamage(damagePerSecond * Time.deltaTime);
	}
}