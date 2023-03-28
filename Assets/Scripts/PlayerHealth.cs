using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerHealth : MonoBehaviour
{
    public Image damageScreen;
    public bool checkDamageScreen = false;
    public Slider healthSlider;

    public static PlayerHealth instance;

    public float maxHpPlayer = 100f;
    public float hpPlayer = 100f;

    public GameObject gameOverdisplay;

    public Animator playerAnimator;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        damageScreen.gameObject.SetActive(false);
    }

    public void DamagePlayer(float damageAmount)
    {
        hpPlayer -= damageAmount;
        playerAnimator.SetTrigger("Hurt");
        AudioManager.instance.playBite();

    }

    public void HealPlayer(float healAmount)
    {
        hpPlayer = Mathf.Min(hpPlayer + healAmount, maxHpPlayer);
    }

       void Update()
    {
        healthSlider.value = hpPlayer;

        if (hpPlayer <= 0 && playerAnimator != null) {
            // Change animation state if player has no health left
            gameOverdisplay.SetActive(true);
            playerAnimator.SetTrigger("Die");
            GameManager.instance.OnPlayerRespawn();
        }
    }

    // Update is called once per frame
    public IEnumerator delayDamageScreen()
    {
        checkDamageScreen = true;
        yield return new WaitForSeconds(0.5f);
        DamagePlayer(10);
        damageScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        damageScreen.gameObject.SetActive(false);
        checkDamageScreen = false;
    }
}