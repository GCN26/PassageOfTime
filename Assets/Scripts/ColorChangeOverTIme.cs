using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeOverTIme : MonoBehaviour
{
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.GetComponent<ManagerScript>().currentEra == 0)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        }
        else if (manager.GetComponent<ManagerScript>().currentEra == 1)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(.9f, .9f, .9f);
        }
        else if (manager.GetComponent<ManagerScript>().currentEra == 2)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(.75f, .750f, .75f);
        }
        else if (manager.GetComponent<ManagerScript>().currentEra == 3)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(.66f, .66f, .66f);
        }
    }
}
