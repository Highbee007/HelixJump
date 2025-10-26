using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int best;
    public int score;

    public int currentStage = 0;

    private BallController ball;

    public static GameManager singleton;
    // Start is called before the first frame update
    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton != this)
        {
            Destroy(gameObject);
        }
        best = PlayerPrefs.GetInt("Highscore");

        ball = GameObject.Find("Ball").GetComponent<BallController>();
    }

    // Update is called once per frame
    public void NextLevel()
    {
        Debug.Log("Next Level was called");
    }

    public void RestartLevel()
    {
        Debug.Log("Game Over");
        // Show ads

        singleton.score = 0;
        ball.ResetBall();

    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;

        if (score > best)
        {
            best = score;
            PlayerPrefs.SetInt("Highscore", score);
        }
    }
}
