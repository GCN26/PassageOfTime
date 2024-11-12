using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpriteAnim : MonoBehaviour
{
    public float timer;

    public Sprite spr1;
    public Sprite spr2;
    public bool spriteis1 = true;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= .5f)
        {
            timer = 0;
            spriteis1 = !spriteis1;

        }
        if (spriteis1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spr1;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spr2;
        }
    }
}
