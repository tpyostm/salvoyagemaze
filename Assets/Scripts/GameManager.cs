using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    

    public void gameOver()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameOver");
        
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scene1");
    }

    public void NextGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scene2");
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}

