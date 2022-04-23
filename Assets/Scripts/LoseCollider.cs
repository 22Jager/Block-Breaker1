using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // бібліотека для перемикання сцен

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) // скріпт спрацьовує коли трігер спрацьовує
    {
        SceneManager.LoadScene("Game Over"); // перемикає сцену на Game Over в данному випадку
    }
}
