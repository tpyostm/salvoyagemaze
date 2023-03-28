using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ChangeSigh : MonoBehaviour
{
    public GameObject txtToDisplay;             //display the UI text
    private bool playerInZone;                  //check if the player is in trigger
    public Image Photo;

   

    public static ChangeSigh instance;
    private void Start()
    {
        playerInZone = false;                   //player not in zone     
        txtToDisplay.SetActive(false);
        Photo.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = 1f;
            Photo.gameObject.SetActive(true);
            txtToDisplay.GetComponent<TextMeshProUGUI>().text = "";     
            AudioManager.instance.playTalk(); 
        }
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))     //if player in zone
        {
            txtToDisplay.SetActive(true);
            playerInZone = true;
            txtToDisplay.GetComponent<TextMeshProUGUI>().text = "Press F to interact read the sign";      
        }
    }

    private void OnTriggerExit(Collider other)     //if player exit zone
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInZone = false;
            txtToDisplay.SetActive(false);
            Photo.gameObject.SetActive(false);
        }
    }
}           
