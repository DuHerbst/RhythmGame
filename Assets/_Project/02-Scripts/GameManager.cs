using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // create the singletoooon
    
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject levelCompleteMenu;

    public bool isPaused;
    public bool isGameOver;
    public bool isLevelComplete;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        isPaused = false;
        Time.timeScale = 1f;
        
        Instance = this;
        
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        levelCompleteMenu.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
        
        if (isPaused || isGameOver || isLevelComplete)
        {
            return;
        }
        
    }

    private void PauseGame()
    {
        if (isGameOver || isLevelComplete)
        {
            return;
        }
        
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        
    }

    private void TogglePauseMenu()
    {
        if (isPaused)
        {
            ResumeGame();
            isPaused = false;
        }

        else
        {
            PauseGame();
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        isPaused = false;
        
        if (isGameOver || isLevelComplete)
        {
            return;
        }
        
        isGameOver = true;
        Time.timeScale = 0f;
        gameOverMenu.SetActive(true);
    }

    public void LevelComplete()
    {
        isPaused = false;
        
        if (isGameOver || isLevelComplete)
        {
            return;
        }
        
        isLevelComplete = true;
        Time.timeScale = 0f;
        levelCompleteMenu.SetActive(true);
    }
    
}
