using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;

    public Player     player;
    public Text       scoreText;
    public GameObject playButton;
    public GameObject gameOver;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        
        this.Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);

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
        this.gameOver.SetActive(true);
        this.playButton.SetActive(true);
        
        this.Pause();
    }
    public void IncreaseScore()
    {
        this.score++;
        this.scoreText.text = this.score.ToString();
    }
}
