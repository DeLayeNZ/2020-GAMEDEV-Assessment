using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int lives = 3;
    int score = 0;

    public Text scoreText;
    public Text livesText;
    public int Lives
    {
        get { return lives; }
        set
        {
            lives = value;
            UpdateUI();
        }
    }

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            UpdateUI();
        }
    }


    void Start ()
    {
        UpdateUI();
    }

    void UpdateUI() 
    {
        scoreText.text = string.Format("Score: {0}", score);
        livesText.text = string.Format("{0} Lives", lives);
    }
}
