using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // бібліотека для перемикання сцен

public class SceneLoader : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit(); // виходимо з гри
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;  // дізнаємося номер цієї сцени
        SceneManager.LoadScene(currentSceneIndex + 1); // підгружаємо наступну
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0); // підгружаємо стартову сцену
        FindObjectOfType<GameStatus>().ResetGame();
    }
}

    
