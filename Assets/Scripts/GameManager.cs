using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int best;
    public int score;
    public GameObject ballPrefab;

    public int currentStage = 0;

    public bool isGameActive;

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
        best = PlayerPrefs.GetInt("Bestscore");
        isGameActive = false;

        ball = GameObject.Find("Ball").GetComponent<BallController>();
    }

    // Update is called once per frame
    public void NextLevel()
    {
        currentStage++;
        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentStage);
    }

    public void RestartLevel()
    {
        Debug.Log("Game Over");
        // Show ads

        singleton.score = 0;
        ball.ResetBall();
        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentStage);
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;

        if (score > best)
        {
            best = score;
            PlayerPrefs.SetInt("Bestscore", score);
        }
    }
    public void StartGame()
    {
        isGameActive = true;
        GameObject.Find("Title").SetActive(false);
        FindObjectOfType<HelixController>().LoadStage(0);
        FindObjectOfType<BallController>().ballRb.useGravity = true;
    }

    public void ChaosMode()
    {
        if (isGameActive)
        {
            Instantiate()
        }
    }
}


