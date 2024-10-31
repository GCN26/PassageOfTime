using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeObject : MonoBehaviour
{
    public GameObject manager;
    //maybe replace this and allow for multiple eras to be selected for one object
    //as for right now, this works
    public enum era
    {
        _0 = 0,_1 = 1,_2 = 2,_3 = 3
    }
    public era inEra;
    public bool eraEnabled = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.GetComponent<ManagerScript>().currentEra == (int)inEra)
        {
            eraEnabled = true;
        }
        else
        {
            eraEnabled = false;
        }
        if (eraEnabled)
        {
            //set child to active
            //allows for collisions and visuals
        }
        else
        {
            
        }
        //make this the parent object of another that gets enabled and disabled when needed.
        //if this is made inactive, then the update function no longer works.
        //this also allows for other objects apart from squares to use this code.
    }
}
