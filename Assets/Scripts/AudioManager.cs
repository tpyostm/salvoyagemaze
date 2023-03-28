using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{

public AudioClip item;
public AudioClip bite;
public AudioClip Interact;
public AudioClip Talk;
public AudioClip Heart;



private AudioSource audioSource;
public static AudioManager instance;

void Start()
{
instance = this;
audioSource = gameObject.AddComponent<AudioSource>();
}

public void playBite(){playsound(bite);}
public void playItem() {playsound(item);}
public void playInteract() {playsound(Interact);}
public void playTalk() {playsound(Talk);}
public void playHearth() {playsound(Heart);}




public void playsound(AudioClip clip)
{
audioSource.PlayOneShot(clip);
}
}