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
    [HideInInspector] public bool isHitPlayer = false;
    [HideInInspector] public bool isHitTower = false;
    [HideInInspector] public bool isHitSafeZone = false;
    // Start is called before the first frame update
    void Awake()
    {
        if (m_player == null)
            m_player = GameObject.FindGameObjectWithTag("Player");
        m_tower = GameObject.FindGameObjectWithTag("Tower");
        if (m_tower == null)
            m_tower = FindObjectOfType<TowerController>().gameObject;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //If the enemies are in the radius of the player but they are not colliding with the player.
        if (InSearchArea.Instance.isInRadius && !isHitPlayer && !isHitSafeZone)
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, m_player.transform.position, m_speed * Time.fixedDeltaTime);
        //If the tower is not within the range of the enemies.
        else if (!isHitTower && !isHitSafeZone)
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, m_tower.transform.position, m_speed * Time.fixedDeltaTime);
    }
    //Colliding with tower or player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Tower"))
        {
            isHitTower = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        if (collision.collider.CompareTag("Player"))
        {
            isHitPlayer = true;
        }
    }
    //Leaving the collision area of the tower or player
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Tower"))
        {
            isHitTower = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        if (collision.collider.CompareTag("Player"))
        {
            isHitPlayer = false;
        }
    }
}
