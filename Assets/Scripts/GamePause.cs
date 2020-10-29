using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    private bool isPaused = false;
    private readonly string mainMenu = "Menu";
    [SerializeField] private float transitionTime = 1f;
    private List<GameObject> childs = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject m_child = transform.GetChild(i).gameObject;
            if (m_child != null)
                childs.Add(m_child);
        }
    }

    //Only call PauseGame()
    public void PauseGame()
    {
        if (isPaused)
        {
            ResumeGame();
            return;
        }

        isPaused = true;
        MakeInvisable(true);
        Time.timeScale = 0;
    }
    public void RestartLevel()
    {
        Time.timeScale = 1;
        MakeInvisable(false);
        StartCoroutine(RestartScene());
    }
    
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        MakeInvisable(false);
        StartCoroutine(LoadLevel(mainMenu));
    }

    private void ResumeGame()
    {
        isPaused = false;
        MakeInvisable(false);
        Time.timeScale = 1;
    }

    private void MakeInvisable(bool isActive)
    {
        foreach (GameObject item in childs)
        {
            item.SetActive(isActive);
        }
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

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
