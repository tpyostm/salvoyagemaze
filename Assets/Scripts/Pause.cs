using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public TextMeshProUGUI textHp;
    public TextMeshProUGUI textCoin;
    public GameObject pauseMenu;
    public GameObject gameOverdisplay;


    public static bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        gameOverdisplay.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
       {
        if(isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
       } 
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenuGame()
    {
        Time.timeScale = 2f;
        SceneManager.LoadScene("MainMenu");
    }
}
