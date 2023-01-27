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
        NumberScore = NumberScore + 1;
        score.text = NumberScore.ToString();

        if( NumberScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", NumberScore);
            highScore.text = NumberScore.ToString();

        }

    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore.text = "0";
        score.text = "0";
        NumberScore = 0;

    }



}
