using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [SerializeField] private Slider m_playerHealth;
    [SerializeField] private Slider m_towerHealth;
    // Start is called before the first frame update
    private void Awake()
    {
        if (m_playerHealth != null || m_towerHealth != null)
        {
            m_playerHealth.maxValue = PlayerController.Instance.health;
            m_towerHealth.maxValue = TowerController.Instance.health;
            m_playerHealth.minValue = 0;
            m_towerHealth.minValue = 0;
            UpdateHealth();
            m_playerHealth.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    private void Update()
    {
        UpdateHealth();
    }
    private void UpdateHealth() 
    {
        if (m_playerHealth != null || m_towerHealth != null)
        {
            m_playerHealth.value = PlayerController.Instance.health;
            m_towerHealth.value = TowerController.Instance.health;
        }
    }
}
