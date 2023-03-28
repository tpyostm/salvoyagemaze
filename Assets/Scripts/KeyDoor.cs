using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyDoor : MonoBehaviour

{
    public GameObject Display;
    public Image Photo;
    public bool checkPhoto = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            ChangeStage.instance.getKey(1);
            gameObject.SetActive(false);
            Display.SetActive(true);
            Photo.gameObject.SetActive(true);
            AudioManager.instance.playItem();


            //delayPhoto();
        }
    }
        // public IEnumerator delayPhoto(){
        //     checkPhoto = true;
        //     yield return new WaitForSeconds(0.5f);
        //     Photo.gameObject.SetActive(true);
        //     yield return new WaitForSeconds(4f);
        //     Photo.gameObject.SetActive(false);
        //     checkPhoto = false;
        // }
    }

