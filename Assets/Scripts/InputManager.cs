using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

// Robin
public class InputManager : MonoBehaviour
{
    [SerializeField] private GamePause pauseMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            pauseMenu.PauseGame();
    }
}
