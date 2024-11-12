using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChangeInTime : MonoBehaviour
{
    public bool inTimeZone = false;
    public GameObject manager;
    public GameObject CreateOnEra;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inTimeZone && manager.GetComponent<ManagerScript>().eraChange)
        {
            GameObject create;
            Debug.Log("Seed Planted");
            create = Instantiate(CreateOnEra,new Vector3(transform.position.x,transform.position.y+.9f,transform.position.z),Quaternion.identity);
            //should be used to chnage instance of object to secondary object whether it be a tree or something else
            Destroy(gameObject);
        }
    }
}
