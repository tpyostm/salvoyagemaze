using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Heart : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth.instance.HealPlayer(20);
             gameObject.SetActive(false);
            AudioManager.instance.playHearth();
        }
    }
}
