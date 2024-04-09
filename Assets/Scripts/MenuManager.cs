using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1.0f;
    }
    public void SceneChangeTo(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("GameScene");
    }
}
