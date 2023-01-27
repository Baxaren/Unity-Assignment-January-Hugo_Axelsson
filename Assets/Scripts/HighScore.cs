using UnityEngine;
using UnityEngine.UI;


public class HighScore : MonoBehaviour
{
    public Text score;
    public Text highScore;

    void start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

    }

    public void ScoreGained ()
    {
        int number = +1;
        score.text = number.ToString();

        if( number > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", number);

        }

    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore.text = "0";

    }



}
