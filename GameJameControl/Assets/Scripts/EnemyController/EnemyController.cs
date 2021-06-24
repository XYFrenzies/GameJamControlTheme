using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is the enemy controls and the way they move.
/// </summary>
public class EnemyController : Singleton<EnemyController>
{
    [SerializeField] private float m_speed = 10.0f;
    [SerializeField] private GameObject m_player;
    private GameObject m_tower;
    [HideInInspector] public bool isHitPlayer = true;
    private bool isHitTower = false;
    // Start is called before the first frame update
    void Awake()
    {
        if(m_player == null)
            m_player = GameObject.FindGameObjectWithTag("Player");
        m_tower = GameObject.FindGameObjectWithTag("Tower");
        if (m_tower == null)
            m_tower = FindObjectOfType<TowerController>().gameObject;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (InSearchArea.Instance.isInRadius)
            Vector3.MoveTowards(gameObject.transform.position, m_player.transform.position, m_speed);
        else if (!isHitTower)
            Vector3.MoveTowards(gameObject.transform.position, m_tower.transform.position, m_speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Tower"))
        {
            isHitTower = true;
        }
        if (collision.collider.CompareTag("Player"))
        {
            isHitPlayer = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Tower"))
        {
            isHitTower = false;
        }
    }
}
