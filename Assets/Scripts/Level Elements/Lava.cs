using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{

    [SerializeField] private float damagePerSecond = 1;
    private Player player;
    bool inLava;

    private void OnEnable()
    {
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
                player = playerObject.GetComponent<Player>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inLava)
        {
            if (player != null)
                player.TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        inLava = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inLava = false;
    }
}
