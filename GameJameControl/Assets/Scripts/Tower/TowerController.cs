using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This will be the towers controls and having a health display.
/// </summary>
public class TowerController : Singleton<TowerController>
{
    public int health = 3;
    private void Update()
    {
        if (health <= 0)
        {
            GlobalValues.Instance.isTowerDead = true;
            GlobalValues.Instance.score = Score.Instance.GetAmount();
            GlobalValues.Instance.time = Timer.Instance.GetCurrentTime();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            EnemyController control = collision.gameObject.GetComponent<EnemyController>();
            if (control.dt > control.timeBetweenHits)
            {
                control.dt = 0;
                health--;
            }
        }
    }
}
