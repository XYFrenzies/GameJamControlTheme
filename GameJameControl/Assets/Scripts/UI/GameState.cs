using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class GameState : MonoBehaviour
{
    private bool hasBeenPaused = false;
    private float buttonDelay = 0f;
    [SerializeField] private GameObject gameMenu = null;
    [SerializeField] private GameObject pauseMenu = null;
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void Update()
    {
        buttonDelay += Time.unscaledDeltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (hasBeenPaused)
                ResumeGame();
            else if (!hasBeenPaused)
                PauseGame();
        }
    }
    private void PauseGame()
    {
        gameMenu.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        hasBeenPaused = true;
        buttonDelay = 0;
    }
    public void ResumeGame()
    {
        gameMenu.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        hasBeenPaused = false;
        buttonDelay = 0;
    }
}
