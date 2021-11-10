using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private const float sceneLoadDelay = 2f;

    public void LoadGame()
    {
        FindObjectOfType<ScoreKeeper>()?.Reset();
        SceneManager.LoadScene("Game");
    }

    public void LoadMenu()
    {
        FindObjectOfType<ScoreKeeper>()?.Reset();
        SceneManager.LoadScene(0);
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad(2, sceneLoadDelay));
    }

    IEnumerator WaitAndLoad(int scene, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game)");
        Application.Quit();
    }

}
