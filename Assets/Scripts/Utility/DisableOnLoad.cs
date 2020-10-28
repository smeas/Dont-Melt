using System;
using UnityEngine;

public class DisableOnLoad : MonoBehaviour
{
	private void Awake()
	{
		gameObject.SetActive(false);
	}
}