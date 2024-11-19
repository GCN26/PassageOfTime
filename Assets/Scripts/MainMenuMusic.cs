using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    public AudioSource audioP;
    public GameObject manager;

    void Update()
    {
        if (manager.GetComponent<MainMenuScript>().started|| manager.GetComponent<MainMenuScript>().started2)
        {
            audioP.mute = true;
        }
    }
}
