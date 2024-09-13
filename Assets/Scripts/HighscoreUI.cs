using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreUi : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject highscoreUIElementPrefab;
    [SerializeField] Transform  elementWrapper;

    [SerializeField] private HighscoreHandler highscoreHandler;
    
    
    public void ShowPanel () {
        panel.SetActive (true);
        this.UpdateHighScoreDisplay();
    }

    public void ClosePanel () {
        panel.SetActive (false);
    }
    
    private void UpdateHighScoreDisplay()
    {
        var sortByScore = this.highscoreHandler.highscoreList.OrderByDescending(x => x.score).ToList();

        
        if (highscoreHandler != null && sortByScore.Count > 0)
        {
            foreach (var score in sortByScore)
            {
                GameObject newElement = Instantiate(highscoreUIElementPrefab, elementWrapper);

                var element = newElement.GetComponent<ScoreElement>();
                element.SetScore(score.name, score.score);
            }
        }
        else
        {
            panel.SetActive(false);
        }
    }
}
