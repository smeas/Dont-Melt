using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterDoor : MonoBehaviour
{
    private Player player;
    public GameObject connectedDoor;
    bool enterThisDoor;

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
        if (enterThisDoor)
        {
            player.transform.position = connectedDoor.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            enterThisDoor = true;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            enterThisDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        enterThisDoor = false;
    }
}
