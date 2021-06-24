using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : Singleton<Score>
{
    private int count = 0;
    [SerializeField] private Text m_scoreText = null;
    [SerializeField] private string textBeforeCountNumber = "";
    // Update is called once per frame
    void Update()
    {
        m_scoreText.text = textBeforeCountNumber + count.ToString();
    }
    public void IncreaseCount(int amount) 
    {
        count += amount;
    }
    public int GetAmount() 
    {
        return count;
    }
}
