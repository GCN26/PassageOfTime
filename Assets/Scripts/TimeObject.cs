using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeObject : MonoBehaviour
{
    public GameObject manager;
    public GameObject child;
    public bool Era1,Era2,Era3,Era4;
    public bool eraEnabled = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    public bool checkIfEnabled()
    {
        if (manager.GetComponent<ManagerScript>().currentEra == 0 && Era1 == true)
        {
            return true;
        }
        else if (manager.GetComponent<ManagerScript>().currentEra == 1 && Era2 == true)
        {
            return true;
        }
        else if (manager.GetComponent<ManagerScript>().currentEra == 2 && Era3 == true)
        {
            return true;
        }
        else if (manager.GetComponent<ManagerScript>().currentEra == 3 && Era4 == true)
        {
            return true;
        }
        else return false;
    }
    void Update()
    {
        if (checkIfEnabled())
        {
            eraEnabled = true;
        }
        else
        {
            eraEnabled = false;
        }
        if (eraEnabled)
        {
            child.gameObject.SetActive(true);
        }
        else
        {
            child.gameObject.SetActive(false);
        }
        //make this the parent object of another that gets enabled and disabled when needed.
        //if this is made inactive, then the update function no longer works.
        //this also allows for other objects apart from squares to use this code.
    }
}
