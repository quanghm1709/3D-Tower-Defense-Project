using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    public bool Detecting(float detectRange, LayerMask detectLayer)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, detectRange, detectLayer))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * detectRange, Color.red);
            return true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * detectRange, Color.blue);
            return false;
        }
    }
}
