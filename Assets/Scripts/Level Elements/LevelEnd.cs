using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

// Robin
public class LevelEnd : MonoBehaviour
{
    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private string levelToLoad = "Lava";
    [SerializeField] private UnityEvent onEnter = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        onEnter.Invoke();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(levelToLoad));
    }

    IEnumerator LoadLevel(string levelName)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }
}
