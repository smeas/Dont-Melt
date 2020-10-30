using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

// Robin
public class UIHealth : MonoBehaviour
{
    [SerializeField] private Player playerScript;
    [SerializeField] private RectTransform healthBar;
    private float startSize = -1;

    private void OnEnable()
    {
        if (playerScript == null)
            playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        playerScript.OnHealthChange.AddListener(UpdateHealth);
    }

    private void OnDisable()
    {
        playerScript.OnHealthChange.RemoveListener(UpdateHealth);
    }

    private void Start()
    {
        if (healthBar == null)
            Debug.LogError("Missig healthBar");
    }

    public void UpdateHealth()
    {
        if (startSize == -1)
            startSize = healthBar.sizeDelta.x;

        healthBar.sizeDelta = new Vector2(Mathf.Round(playerScript.HealthFraction * startSize), healthBar.sizeDelta.y);
    }
}
