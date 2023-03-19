using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeStage : MonoBehaviour
{
    public GameObject txtToDisplay;             //display the UI text
    private bool playerInZone;                  //check if the player is in trigger
    public string sceneName;
    public int Key = 0;

    public static ChangeStage instance;
     private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        playerInZone = false;                   //player not in zone     
        txtToDisplay.SetActive(false);
    }

    private void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.F) && Key == 1)
        {
            Time.timeScale = 1f;
            txtToDisplay.GetComponent<TextMeshProUGUI>().text = "GJ";
            SceneManager.LoadScene(sceneName);
        }
        else if (playerInZone && Input.GetKeyDown(KeyCode.F) && Key == 0)    //if player doesn't have key, display message
            {
            txtToDisplay.GetComponent<TextMeshProUGUI>().text = "You need a key to enter";
            }
    }
    public void getKey(int getkey)
    {
        Key += getkey;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))     //if player in zone
        {
            txtToDisplay.SetActive(true);
            playerInZone = true;
            txtToDisplay.GetComponent<TextMeshProUGUI>().text = "Press F";      
        }
    }

    private void OnTriggerExit(Collider other)     //if player exit zone
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInZone = false;
            txtToDisplay.SetActive(false);
        }
    }
}           
