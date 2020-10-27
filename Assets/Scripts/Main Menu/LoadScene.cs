using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [Header("Scene names")]
    [Tooltip("Name of the scene to load. Make sure the scene is added in the build settings.")]
    public string gameScene = "SampleScene";

    public void LoadGame()
    {
        SceneManager.LoadScene(gameScene, LoadSceneMode.Single);
    }

    public void SelectLevel()
    {
        Debug.Log("Not implemented yet");
    }

    public void Settings()
    {
        Debug.Log("Not implemented yet");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
