using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeZone : MonoBehaviour
{
    //change this to be a selection for what needs to be done here
    //currently only allows for seeds to be planted to make trees
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Seed"))
        {
            collision.GetComponent<ObjectChangeInTime>().inTimeZone = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Seed"))
        {
            collision.GetComponent<ObjectChangeInTime>().inTimeZone = false;
        }
    }
}
