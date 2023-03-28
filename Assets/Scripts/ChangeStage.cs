using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class ChangeStage : MonoBehaviour
{
    public GameObject txtToDisplay;             //display the UI text
    private bool playerInZone;                  //check if the player is in trigger
    public string sceneName;
    public int Key = 0;
    public GameObject Display;
    public Image Photo3;



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
        if (playerInZone && Input.GetKeyDown(KeyCode.F) && Key == 2)
        {
            Time.timeScale = 1f;
            AudioManager.instance.playInteract();
            txtToDisplay.GetComponent<TextMeshProUGUI>().text = "GJ";
             Photo3.gameObject.SetActive(true);
             StartCoroutine(LoadSceneWithDelay(5f));
        }
         else if (playerInZone && Input.GetKeyDown(KeyCode.F) && Key == 1)    //if player doesn't have key, display message
            {
            txtToDisplay.GetComponent<TextMeshProUGUI>().text = "Need one more item";
            AudioManager.instance.playTalk();
            }
        else if (playerInZone && Input.GetKeyDown(KeyCode.F) && Key == 0)    //if player doesn't have key, display message
            {
            txtToDisplay.GetComponent<TextMeshProUGUI>().text = "Do what the sign writes then comeback to me ";
            Display.SetActive(true);
            AudioManager.instance.playTalk();
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
            txtToDisplay.GetComponent<TextMeshProUGUI>().text = "Press F to talk with NPC";      
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
    private IEnumerator LoadSceneWithDelay(float delay)
{
    yield return new WaitForSeconds(delay);
    SceneManager.LoadScene(sceneName);
}
}           
