using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is the enemy controls and the way they move.
/// </summary>
public class EnemyController : Singleton<EnemyController>
{
    [HideInInspector] public bool isInRadius;
    [SerializeField] private float m_speed = 10.0f;
    [SerializeField] private GameObject m_player;
    public float timeBetweenHits = 2.0f;
    public float playerDamage = 0.1f;
    public float towerDamage = 0.1f;
    private GameObject m_tower;
    public Animator anim;
    [HideInInspector] public float dt = 0.0f;
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
    void Update()
    {
        dt += Time.deltaTime;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //If the enemies are in the radius of the player but they are not colliding with the player.
        if (isInRadius && !isHitPlayer && !isHitSafeZone)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, m_player.transform.position, m_speed * Time.fixedDeltaTime);
            Vector3 pdir = (transform.position - m_player.transform.position).normalized;
            AnimationSet(pdir);

        }
        //If the tower is not within the range of the enemies.
        else if (!isHitTower && !isHitSafeZone)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, m_tower.transform.position, m_speed * Time.fixedDeltaTime);
            Vector3 tdir = (transform.position - m_tower.transform.position).normalized;
            AnimationSet(tdir);

        }
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
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(playerDamage);

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


    public void AnimationSet(Vector3 direction)
    {
        // Debug.Log("Pos X:" + direction.x + " | Pos Y:" + direction.z);
        anim.SetFloat("Xpos", direction.x); anim.SetFloat("Ypos", direction.z);

    }
}
