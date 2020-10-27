﻿using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private Transform player = null;

	private void LateUpdate()
	{
		Vector3 position = transform.position;
		position.x = player.position.x;
		position.y = player.position.y;
		transform.position = position;
	}
}