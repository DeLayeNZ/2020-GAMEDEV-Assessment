using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScreenController : MonoBehaviour
{

    public Text playerScore;
    public Text highScore;


    void Start()
    {
        highScore.text = "";

        int lastScore = PlayerPrefs.GetInt("lastscore", 0);
        int hiScore = PlayerPrefs.GetInt("highscore", 0);

        if (lastScore > 0 && lastScore > hiScore)
        {
            PlayerPrefs.SetInt("highscore", lastScore);
            highScore.text = "NEW HIGH SCORE: " + lastScore;
        }

        playerScore.text = lastScore.ToString();
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MainMenu");
    }
}
