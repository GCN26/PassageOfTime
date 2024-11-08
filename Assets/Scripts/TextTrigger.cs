using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextTrigger : MonoBehaviour
{
    public bool textOn;
    public TextMeshProUGUI textEn;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textOn = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textOn = false;
        }
    }
    private void Update()
    {
        textEn.gameObject.SetActive(textOn);
    }
}
