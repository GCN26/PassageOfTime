using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChangeEra : MonoBehaviour
{
    public GameObject manager;

    public Sprite spr1;
    public Sprite spr2;
    public Sprite spr3;
    public Sprite spr4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //maybe just darken the sprite instead of changing it cause it looks BAD
        if(manager.GetComponent<ManagerScript>().currentEra == 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = spr1;
        }
        else if (manager.GetComponent<ManagerScript>().currentEra == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = spr2;
        }
        else if (manager.GetComponent<ManagerScript>().currentEra == 2)
        {
            this.GetComponent<SpriteRenderer>().sprite = spr3;
        }
        else if (manager.GetComponent<ManagerScript>().currentEra == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = spr4;
        }
    }
}
