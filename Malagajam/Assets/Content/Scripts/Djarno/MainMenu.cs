using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public AudioSource audio;
    public AudioSource audioExit;

    public void playButton()
    {
        audio.Play();
    }
    public void exitButton()
    {
        audioExit.Play();
    }
}
