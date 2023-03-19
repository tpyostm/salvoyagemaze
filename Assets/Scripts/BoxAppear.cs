using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAppear : MonoBehaviour
{
    public GameObject PuzzleDoor;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (PuzzleDoor.activeSelf)
        {
            PuzzleDoor.SetActive(false);
        }
        else
        {
            PuzzleDoor.SetActive(true);
        }
    }
}