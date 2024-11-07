using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform followThis;
    public float smoothTime;
    public Vector3 offset;

    public float clampYMin;
    public float clampYMax;
    public float clampXMin;
    public float clampXMax;
    private void Update()
    {
        float clampedYVal = Mathf.Clamp(followThis.transform.position.y, clampYMin, clampYMax);
        float clampedXVal = Mathf.Clamp(followThis.transform.position.x, clampXMin, clampXMax);
        transform.position = new Vector3(clampedXVal,clampedYVal,transform.position.z);
    }
}
