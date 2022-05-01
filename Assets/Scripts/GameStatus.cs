using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    //config param
    [SerializeField] int pointsPerBlockDestroyed = 85;
    [SerializeField] TextMeshProUGUI scoreText;
    
    //state variables
    [SerializeField] int currentScore = 0;

    private void Awake() 
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            ResetGame();
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() 
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = currentScore.ToString();
    }

    public void AddToScore() 
    {
        currentScore += pointsPerBlockDestroyed;
    }

    public void ResetGame() 
    {
        Destroy(gameObject);
    }
}
