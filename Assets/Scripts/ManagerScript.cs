using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public int currentEra = 0;
    public bool eraChange = false;

    // Update is called once per frame
    void Update()
    {
        if (eraChange) eraChange = false;
    }
}
