using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Text highScore;

    //sets the last score back to 0
    //loads the Game scene if the play button is pressed
    public void PlayGame()
    {
        PlayerPrefs.SetInt("lastscore", 0);
        SceneManager.LoadScene("Game");
    }


    //gets the high score and displays it on the main menu
    void Start()
    {
        int hiScore = PlayerPrefs.GetInt("highscore", 0);
        highScore.text = "CURRENT HIGH SCORE: " + hiScore;
    }


    //also loads the game from the main menu if the LEFT CNTRL button is pressed
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            PlayGame();
        }
    }
}
