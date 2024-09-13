using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    private int yourScore;

    public           Player           player;
    public           Text             scoreText;
    public           Text             yourScoreText;
    public           GameObject       playButton;
    public           GameObject       pannel;
    public           TMP_Text         inputNameText;
    public           GameObject       gameWaiting;
    [SerializeField] HighscoreHandler highscoreHandler;
    
    // create a list to save a score list.
    List<HighscoreElement> highscoreList = new List<HighscoreElement>();
    
    // create a file name.
    [SerializeField] string filename;
    
    private void Awake()
    {
        Application.targetFrameRate = 60;
        
        this.Pause();
    }
    
    private void Start()
    {
        this.highscoreList = FileHandler.ReadListFromJSON<HighscoreElement>(filename);
    
        if (this.highscoreList == null)
        {
            this.highscoreList = new List<HighscoreElement>();
        }
    }


    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);

        Time.timeScale = 1f;
        this.player.enabled = true;
        
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        this.player.enabled = false;
    }
    
    public void GameOver()
    {
        this.playButton.SetActive(false);
        this.yourScoreText.text = score.ToString();
        this.Pause();
        this.pannel.SetActive(true);
    }
    public void SaveScore()
    {
        string playerName = inputNameText.text.Trim();

        if (!string.IsNullOrEmpty(playerName))
        {
            this.highscoreList.Add(new HighscoreElement(this.score, playerName));
            //this.highscoreHandler.AddHighscoreIfPossible(new HighscoreElement(this.score, playerName));
            FileHandler.SaveToJSON<HighscoreElement>(this.highscoreList, filename);
            this.pannel.SetActive(false);
            this.gameWaiting.SetActive(true);
        }
    }
    
    
    public void IncreaseScore()
    {
        this.score++;
        this.scoreText.text = this.score.ToString();
    }

    public void ReplayGame()
    {
        Debug.Log("be clicked!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        this.gameWaiting.SetActive(false);
    }
}
