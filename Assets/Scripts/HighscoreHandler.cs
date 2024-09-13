using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HighscoreHandler : MonoBehaviour
{
    public List<HighscoreElement>  highscoreList = new List<HighscoreElement> ();
    [SerializeField] int    maxCount = 5;
    [SerializeField] string filename;
    
    private void Start () {
        LoadHighscores ();
    }

    private void LoadHighscores () {
        Debug.Log("Loading Highscores");
        highscoreList = FileHandler.ReadListFromJSON<HighscoreElement> (filename);

        // soring list by score
        //var sortByScore = this.highscoreList.OrderBy(x => x.score).ToList();
        
        while (highscoreList.Count > maxCount) {
            highscoreList.RemoveAt (maxCount);
        }
    }
}
