using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageAppear : MonoBehaviour
{
    public GameObject AppleDisplay; 
    public GameObject StaffDisplay; 
    public GameObject NpcDisplay; 
    public GameObject Apple1Display; 
    public GameObject Staff1Display; 
    public GameObject Npc1Display; 
    public Image Photo;
    public Image Photo2;
    public Image Photo3;



    public GameObject Apple; 
    public GameObject Staff; 
    public GameObject Npc;
    

    // Start is called before the first frame update
    void Start()
    {
       Apple1Display.SetActive(false);
       Staff1Display.SetActive(false);
       Npc1Display.SetActive(false);
       Photo.gameObject.SetActive(false);
       Photo2.gameObject.SetActive(false);
       Photo3.gameObject.SetActive(false);



       AppleDisplay.SetActive(true);
       StaffDisplay.SetActive(true);
       NpcDisplay.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Apple)
        {
            Apple1Display.SetActive(true);
            AppleDisplay.SetActive(false);
        }
        else if (other.gameObject == Staff)
        {
            Staff1Display.SetActive(true);
            StaffDisplay.SetActive(false);
        }
        else if (other.gameObject == Npc)
        {
            Npc1Display.SetActive(true);
            NpcDisplay.SetActive(false);
        }
    }
}