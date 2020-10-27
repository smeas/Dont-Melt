using UnityEngine;

public class ContinuousDamager : MonoBehaviour
{
	[SerializeField, Tooltip("The player to damage. (optional)")]
	private Player player = null;

	[SerializeField] private float damagePerSecond = 1;

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
			player.Health -= damagePerSecond * Time.deltaTime;
	}
}