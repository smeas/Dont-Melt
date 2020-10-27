using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private float transitionTime = 2f;
    [Header("Scene names")]
    [Tooltip("Name of the scene to load. Make sure the scene is added in the build settings.")]
    public string gameScene = "SampleScene";

    public void LoadGame()
    {
        StartCoroutine(LoadLevel(gameScene));
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

    IEnumerator LoadLevel(string levelName)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(gameScene, LoadSceneMode.Single);
    }
}
