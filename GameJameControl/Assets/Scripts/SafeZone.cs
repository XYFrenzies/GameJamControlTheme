using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SafeZone : MonoBehaviour
{
    [SerializeField] private Text m_timer = null;
    [SerializeField] private int amountTillCooldown = 5;
    [SerializeField] private float timeBeforeHospitalCooldown = 2.00f;
    private float seconds = 0;
    private int cooldown = 0;
    private bool cooldownHasStarted = false;
    void Awake() 
    {
        m_timer.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (cooldown >= amountTillCooldown && !cooldownHasStarted)
        {
            cooldownHasStarted = true;
            seconds = timeBeforeHospitalCooldown;
        }
        if (cooldownHasStarted)
        {
            seconds -= 1 * Time.deltaTime;
            DisplayTime(seconds);
            if (seconds <= 0)
            {
                cooldownHasStarted = false;
                cooldown = 0;
            }
        }

    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && cooldown >= amountTillCooldown && !cooldownHasStarted)
        {
            Destroy(other.gameObject);
            Score.Instance.IncreaseCount();
            cooldown += 1;
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); //converts time to minutes
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); // converts time 

        m_timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
