using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementBall : MonoBehaviour
{
    //sets the boundies of the play area
    readonly float LEFTRIGHT = 7.75f;
    readonly float TOPBOTTOM = 4.25f;

    //sets the ball speed and if it is served or not. by default, it is not
    Vector2 speed = new Vector2(4, -4);
    bool BallServed = false;
    int brickCount = 0;


    //calls upon the audio clips and game controller, sets them as public classes
    public AudioClip WallHit;
    public AudioClip PlayerHit;
    public AudioClip BrickHit;
    public AudioClip Missed;
    public GameController gameController;

    void Start()
    {
        gameController.Score = PlayerPrefs.GetInt("lastscore", 0);
    }


    //runs a detection to start the while loop if button is pressed and the ball IS NOT served
    void Update()
    {
        if (Input.GetButton("Fire1") && !BallServed)
        {
            BallServed = true;
            StartCoroutine(Run());
        }
    }

    // while loop that controls ball movement and interaction with certain elements
    IEnumerator Run()
    {
        while (BallServed)
        {
            //moves the ball around the play area
            Vector3 delta = speed * Time.deltaTime;
            Vector3 newPos = transform.position + delta;

            // changes the balls position relative to the walls and ceiling and plays a sound
            if (newPos.x < -LEFTRIGHT)
            {
                PlayClip(WallHit);
                newPos.x = -LEFTRIGHT;
                speed.x *= -1;
            }
            else if (newPos.x > LEFTRIGHT)
            {
                PlayClip(WallHit);
                newPos.x = LEFTRIGHT;
                speed.x *= -1;
            }
            else if (newPos.y > TOPBOTTOM)
            {
                PlayClip(WallHit);
                newPos.y = TOPBOTTOM;
                speed.y *= -1;
            }
            else if (newPos.y < -TOPBOTTOM)
            {
                //ball falls off the screen
                BallServed = false;
                newPos = new Vector3(7.75f, -1, 0);
                PlayClip(Missed);
                gameController.Lives--;

                //game over
                if (gameController.Lives == 0)
                {
                    //saves score of most recently played game
                    PlayerPrefs.SetInt("lastscore", gameController.Score);

                    //loads the game over screen
                    SceneManager.LoadScene("GameOver");
                }
            }

            transform.position = newPos;
            yield return new WaitForEndOfFrame();
        }

    }

    void OnCollisionEnter2D(Collision2D c)
    {
        //ball collision with bricks
        speed.y *= -1;
        if (c.gameObject.tag != "Player")
        {
            Destroy(c.gameObject);
            PlayClip(BrickHit);
            gameController.Score += 10;
            brickCount++;

            if (brickCount == 75)
            {
                PlayerPrefs.SetInt("lastscore", gameController.Score);
                SceneManager.LoadScene("Game");
            }
        }

        //ball collision with player
        else
        {
            PlayClip(PlayerHit);
            gameController.Score += 5;
        }
    }

    //plays each audio clip as one shot samples. 
    //i believe this stops sounds from overlapping in weird ways if there is many sounds playing at once
    void PlayClip(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
