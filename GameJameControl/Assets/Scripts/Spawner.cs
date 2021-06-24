using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objToSpawn;
    public float repeatRateMin;
    public float repeatRateMax;
    public float startTime;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObj", startTime, Random.Range(repeatRateMin, repeatRateMax));
    }

    void SpawnObj()
    {
        Instantiate(objToSpawn, gameObject.transform.position, gameObject.transform.rotation);
    }
}
