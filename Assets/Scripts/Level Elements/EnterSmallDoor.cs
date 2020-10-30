using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

// Daniel
public class EnterSmallDoor : MonoBehaviour
{
    private Player player;
    public GameObject connectedDoor;

    private bool keyDown;
    private bool atDoor;
    private CinemachineBrain cameraBrain;

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
        if (atDoor && Input.GetKeyDown(KeyCode.W))
        {
            keyDown = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        atDoor = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        atDoor = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (keyDown)
        {
            Vector3 offset = connectedDoor.transform.position - player.transform.position;
            player.transform.position += offset;

            cameraBrain = Camera.main.GetComponent<CinemachineBrain>();
            CinemachineVirtualCamera virtualCamera = cameraBrain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
            virtualCamera.OnTargetObjectWarped(player.transform, offset);

            keyDown = false;
        }
    }
}
