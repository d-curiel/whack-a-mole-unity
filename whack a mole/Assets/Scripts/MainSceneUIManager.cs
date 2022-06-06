using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneUIManager : MonoBehaviour
{
    [SerializeField]
    Text timeRemainingText;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Button startGameButton;
    [SerializeField]
    Image instructionsPanel;
    [SerializeField]
    Button pauseButton;
    [SerializeField]
    Image pausePanel;
    [SerializeField]
    Button resumeButton;
    [SerializeField]
    Button quitButton;
    [SerializeField]
    Button restartButton;
    [SerializeField]
    Button mainMenuButton;
    [SerializeField]
    Text finalScoreText;
    [SerializeField]
    Image gameOverPanel;
    
    public static MainSceneUIManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start() {
        startGameButton.onClick.AddListener(StartGame);
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
        quitButton.onClick.AddListener(QuitGame);
        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(QuitGame);
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            PauseGame();
        }
    }

    private void StartGame()
    {
        startGameButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        instructionsPanel.gameObject.SetActive(false);
        GameManager.instance.StartGame();
    }

    private void PauseGame()
    {
        GameManager.instance.PauseGame();
        pauseButton.enabled = false;
        pausePanel.gameObject.SetActive(true);
    }

    private void ResumeGame()
    {
        GameManager.instance.StartGame();
        pauseButton.enabled = true;
        pausePanel.gameObject.SetActive(false);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver(string score){
        gameOverPanel.gameObject.SetActive(true);
        finalScoreText.text = score;
    }
    
    public void setScore(string score){
        scoreText.text = score;
    }

    public void setTimeRemaining(string timeRemaining){
        timeRemainingText.text = timeRemaining;
    }
}
