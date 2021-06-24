using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InSearchArea : Singleton<InSearchArea>
{
    [HideInInspector] public bool isInRadius;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            isInRadius = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            isInRadius = false;
        }
    }
}
