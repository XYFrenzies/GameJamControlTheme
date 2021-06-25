using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverUI : MonoBehaviour
{
    [SerializeField] private string sceneToPlayAgain = "SampleScene";
    [SerializeField] private string m_towerDestroyedText = "Tower was Destroyed";
    [SerializeField] private string m_playerDiedText = "Player Died";
    [SerializeField] private Text m_scoreText = null;
    [SerializeField] private Text m_timeText = null;
    [SerializeField] private Text m_behaviourText = null;
    // Start is called before the first frame update
    void Start()
    {
        if (GlobalValues.Instance != null)
        {
            m_scoreText.text = GlobalValues.Instance.score.ToString();
            m_timeText.text = GlobalValues.Instance.time;
            if (GlobalValues.Instance.isTowerDead)
                m_behaviourText.text = m_towerDestroyedText;
            else
                m_behaviourText.text = m_playerDiedText;
        }
    }
    public void StartAgain() 
    {
        GlobalValues.Instance.RestartGlobalValues();
        SceneManager.LoadScene(sceneToPlayAgain);
    }
    public void QuitApplication() 
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
