using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    [SerializeField]private float timeBeforeAllDelete = 5.0f;
    private bool newKarrenInArea;
    private float timer;
    private List<GameObject> m_karrens;
    // Start is called before the first frame update
    void Start()
    {
        m_karrens = new List<GameObject>();
    }
    private void Update()
    {
        if (newKarrenInArea == true)
        {
            timer += Time.deltaTime;
            if (timer > timeBeforeAllDelete)
            {
                //Makes an effect for when the karrens die.
                DeleteGameObjects();
                newKarrenInArea = false;
                Score.Instance.IncreaseCount();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            m_karrens.Add(other.gameObject);
            newKarrenInArea = true;
            foreach (var karren in m_karrens)
            {
                karren.GetComponent<EnemyController>().isHitSafeZone = true;
            }
        }
    }
    private void DeleteGameObjects() 
    {
        foreach (var karren in m_karrens)
        {
            Destroy(karren);
        }
    }
}
