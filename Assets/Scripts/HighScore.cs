using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HighScore : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text highScore;
    public int NumberScore;

    void Start()
    {
        int v = PlayerPrefs.GetInt("HighScore", 0);
        highScore.text = v.ToString("000");
        Debug.Log($"Start score {v}");

    }


    public void ScoreGained ()
    {
        NumberScore = NumberScore + 1;  // add 1 to score
        score.text = NumberScore.ToString("000");

        if( NumberScore > PlayerPrefs.GetInt("HighScore", 0))  // if score is more than high score, record high score
        {
            PlayerPrefs.SetInt("HighScore", NumberScore);
            highScore.text = NumberScore.ToString("000");

        }



    }

    public void ResetScore()  // reset highscore as well as current score
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore.text = "000";
        score.text = "000";
        NumberScore = 0;

    }



}
