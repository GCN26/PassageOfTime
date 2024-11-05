using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChangeInTime : MonoBehaviour
{
    public bool inTimeZone = false;
    public GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inTimeZone && manager.GetComponent<ManagerScript>().eraChange)
        {
            Debug.Log("Seed Planted");
            //should be used to chnage instance of object to secondary object whether it be a tree or something else
            Destroy(gameObject);
        }
    }
}
