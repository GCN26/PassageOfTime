using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public bool buttonOn;
    public GameObject turnOn;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            buttonOn = true;
        }
    }
    private void Update()
    {
        turnOn.gameObject.SetActive(!buttonOn);
    }
}
