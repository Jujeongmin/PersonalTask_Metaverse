using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button restartButton;
    public Button exitButton;

    public TextMeshProUGUI scoreText;

    void Start()
    {
        restartButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        restartButton.onClick.AddListener(OnRestartButtonClick);
        exitButton.onClick.AddListener(OnExitButtonCLick);
    }

    public void ReStartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void OnRestartButtonClick()
    {
        ReStartGame();
    }

    private void OnExitButtonCLick()
    {
        ExitGame();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
