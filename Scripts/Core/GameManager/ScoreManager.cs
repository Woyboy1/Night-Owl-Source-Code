using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int currentScore = 0;

    public static ScoreManager instance;

    public int CurrentScore => currentScore;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void IncrementScore()
    {
        currentScore++;
    }

    public void DecrementScore()
    {
        currentScore--;
    }

    public void ResetScores()
    {
        currentScore = 0;
    }
}
