using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public static GameManager Instance { get { return gameManager; } }

    private int currentScore = 0;

    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        FindUIManager();
        ResetScore();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindUIManager();
        ResetScore();
    }

    private void FindUIManager()
    {
        uiManager = FindObjectOfType<UIManager>();
        if (uiManager == null)
        {
            Debug.LogError("UIManager is null");
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.restartButton.gameObject.SetActive(true);
        uiManager.exitButton.gameObject.SetActive(true);               
    }

    public void RestartGame()
    {        
        uiManager.ReStartGame();
    }

    private void ResetScore()
    {
        currentScore = 0;
        if(uiManager != null)
        {
            uiManager.UpdateScore(currentScore);
        }
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);
    }
}
