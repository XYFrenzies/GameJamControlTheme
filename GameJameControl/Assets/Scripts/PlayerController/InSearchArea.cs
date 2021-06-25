using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InSearchArea : Singleton<InSearchArea>
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().isInRadius = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().isInRadius = false;
        }
    }
}
