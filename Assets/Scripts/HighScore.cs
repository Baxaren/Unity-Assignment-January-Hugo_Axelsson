using UnityEngine;
using UnityEngine.UI;


public class HighScore : MonoBehaviour
{
    public Text score;
    public Text highScore;
    public int NumberScore;

    void start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

    }

    public void ScoreGained ()
    {
        NumberScore = NumberScore + 1;  // add 1 to score
        score.text = NumberScore.ToString();

        if( NumberScore > PlayerPrefs.GetInt("HighScore", 0))  // if score is more than high score, record high score
        {
            PlayerPrefs.SetInt("HighScore", NumberScore);
            highScore.text = NumberScore.ToString();

        }

    }

    public void ResetScore()  // reset highscore as well as current score
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore.text = "0";
        score.text = "0";
        NumberScore = 0;

    }



}
