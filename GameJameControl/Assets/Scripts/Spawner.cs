using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Singleton<Spawner>
{
    public GameObject objToSpawn;
    public float repeatRateMin;
    public float repeatRateMax;
    public float startTime;

    private List<GameObject> m_enemies = null;

    // Start is called before the first frame update
    void Start()
    {
        m_enemies = new List<GameObject>();
        InvokeRepeating("SpawnObj", startTime, Random.Range(repeatRateMin, repeatRateMax));
    }

    void SpawnObj()
    {
        Instantiate(objToSpawn, gameObject.transform.position, gameObject.transform.rotation);

    }
}
