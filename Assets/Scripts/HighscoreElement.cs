using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HighscoreElement
{
    public int    score;
    public string name;

    public HighscoreElement(int score, string name)
    {
        this.score = score;
        this.name  = name;
    }
    
}
