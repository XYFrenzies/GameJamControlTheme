using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This will be the towers controls and having a health display.
/// </summary>
public class TowerController : Singleton<TowerController>
{
    [SerializeField] private float timeBetweenHits = 2.0f;
    private float dt = 0.0f;
    public int health = 3;
    private void Update()
    {
        dt += Time.deltaTime;
        if (health <= 0)
        {
            //Do Something
        }
        else if (EnemyController.Instance.isHitTower && dt >= timeBetweenHits)
        {
            dt = 0;
            health--;
        }
        else if (dt > timeBetweenHits)
            dt = 0;
    }
}
