using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreElement : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI nameText;
   [SerializeField] private TextMeshProUGUI scoreText;

   public void SetScore(string namePlayer, int score)
   {
      nameText.text  = namePlayer;
      scoreText.text = score.ToString();
   }
}
