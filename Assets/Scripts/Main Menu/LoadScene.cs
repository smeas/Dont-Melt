using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private float transitionTime = 1f;
    [Header("Scene names")]
    [Tooltip("Name of the scene to load. Make sure the scene is added in the build settings.")]
    public string gameScene = "Main";
    private string iceScene = "Ice";
    private string lavaScene = "Lava";
    private string menuScene = "Menu";

    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel(menuScene));
    }

    public void LoadGame()
    {
        StartCoroutine(LoadLevel(gameScene));
    }

    public void LoadIce()
    {
        StartCoroutine(LoadLevel(iceScene));
    }

    public void LoadLava()
    {
        StartCoroutine(LoadLevel(lavaScene));
    }

    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator LoadLevel(string levelName)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }
}
