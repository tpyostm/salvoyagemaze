using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public int maxHealth = 3;
    public int hp;

    public bool isFlash;

    public HealthBar healthBar;

    public static PlayerMovement instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
        Physics.IgnoreLayerCollision(7, 8, false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isFlash)
        {
            getDamage();
        }
    }

    void getDamage()
    {
        hp--;
        healthBar.SetHealth(hp);
        //AudioManager.instance.playenemyHit();
        isFlash = true;
        Physics.IgnoreLayerCollision(7, 8, true);
        StartCoroutine(flash());

        if(hp <= 0)
        {
            this.gameObject.SetActive(false);
            GameManager.instance.gameOver();
            

        }
    }

    

    IEnumerator flash()
    {
        for(int i = 0; i< 10; i++)
        {
            GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(0.1f);
            GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        isFlash = false;
        Physics.IgnoreLayerCollision(7, 8, false);
    }

    public void addHP()
    {
        hp++;
        healthBar.SetHealth(hp);
        if(hp > GameManager.instance.maxHp)
        {
            hp = GameManager.instance.maxHp;
            
        }
    }

}