using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : Singleton<Score>
{
    [SerializeField] private int scoreAmount = 1;
    private int count = 0;
    [SerializeField] private Text m_scoreText = null;
    [SerializeField] private string textBeforeCountNumber = "";
    // Update is called once per frame
    void Update()
    {
        m_scoreText.text = textBeforeCountNumber + count.ToString();
    }
    public void IncreaseCount() 
    {
        count += scoreAmount;
    }
    public int GetAmount() 
    {
        return count;
    }
}
