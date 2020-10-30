using System;
using UnityEngine;

// Jonatan
public class DisableOnLoad : MonoBehaviour
{
	private void Awake()
	{
		gameObject.SetActive(false);
	}
}