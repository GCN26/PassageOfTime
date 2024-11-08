using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlashScript : MonoBehaviour
{
    public float timer;
    public bool polarity;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(polarity) timer += Time.deltaTime;
        else timer -= Time.deltaTime;
        Color tmp = this.GetComponent<SpriteRenderer>().color;
        tmp.a = timer*2;
        this.GetComponent<SpriteRenderer>().color = tmp;
        if (timer > .55 || timer <= -.2f) polarity = !polarity;
    }
}
