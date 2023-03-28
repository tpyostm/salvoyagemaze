using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int maxHp = 3;
    public static GameManager instance;
    public float changeTime;
    public string sceneName;
    
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
        SceneManager.LoadScene("Playground");
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
     
     public void OnPlayerDeath()
    {
        
    }

    // สร้างฟังก์ชันสำหรับการเริ่มเกมใหม่
     public void RestartGame()
    {
       changeTime -= Time.deltaTime;
        if(changeTime <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
        // เช่น รีเซ็ตสถานะของเกมทั้งหมด เริ่มเวลาใหม่ หรือเริ่มที่หน้าจอเริ่มต้น
    // สร้างฟังก์ชันสำหรับการเรียกใช้ทั้งสองฟังก์ชัน
    public void OnPlayerRespawn()
    {
        // เรียกใช้ฟังก์ชันเมื่อผู้เล่นกลับมาจากการตาย
        OnPlayerDeath();
        RestartGame();
    }
    
}


