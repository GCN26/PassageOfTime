using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryMusic : MonoBehaviour
{
    public AudioSource audioP;
    public GameObject manager;

    void Update()
    {
        if (manager.GetComponent<EndManager>().gotoMenu || manager.GetComponent<EndManager>().gotoLast)
        {
            audioP.mute = true;
        }
    }
}
