using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGameManager : MonoBehaviour
{
    public static GameGameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }


    }

    int score;
    public TMP_Text scoreText;
    public GameObject GameoverPanel;
    public TMP_Text currentText;
    public TMP_Text hightscore;
    public Button restartButton;
    public Button ReturntoHome;






    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
        GameoverPanel.SetActive(false);
        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(RestartLevel);
        ReturntoHome.onClick.AddListener(ReturtoHome);

        currentText.text = PlayerPrefs.GetInt("Score").ToString();
        hightscore.text = PlayerPrefs.GetInt("HighScore").ToString();



    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        PlayerPrefs.SetInt("Score ",score);
        currentText.text = PlayerPrefs.GetInt("Score").ToString();
        hightscore.text = PlayerPrefs.GetInt("HighScore").ToString();

        GameoverPanel.SetActive(true);
    }

    private const string MainMenu = "MainMenu";
    private const string Gameplay = "Gameplay";
    public void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Gameplay);
    
}


    public void ReturtoHome()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(MainMenu);
    }
}