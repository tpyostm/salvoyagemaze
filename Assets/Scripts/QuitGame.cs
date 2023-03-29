using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
   public float changeTime;

        private void Update()
    {
        changeTime -= Time.deltaTime;
        if(changeTime <= 0)
        {
        Application.Quit();
        }
    }
}
