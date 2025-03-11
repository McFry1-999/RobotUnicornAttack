using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresGameOver : MonoBehaviour
{
 
 [SerializeField]
 private List<Text> scoresText;

 [SerializeField]

 private Text  FinalScoreText;

 private int scoreIndex = 0;

 public void SetScore(int score)
 {
    scoresText[scoreIndex].text = score.ToString();
    scoreIndex++;
 }

 public void SetFinalScore(int score)
 {
    FinalScoreText.text = score.ToString();
 }

 public void Restart()
 {
    scoreIndex = 0;
    FinalScoreText.text = "0";
    foreach(Text scoreText in scoresText)
    {
        scoreText.text = "0";
    }
 }
}
