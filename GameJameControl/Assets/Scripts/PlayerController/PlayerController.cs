using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [Range(0.1f, 10f)]
    public float radius = 1;
    [HideInInspector] public bool isInRadius;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            isInRadius = true;
        }
    }
}
