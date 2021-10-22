using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public static GameController instance;
    public GameObject gameOver;

    void Start()
    {
        instance = this;
    }

    public void updateScoreText()
    {
        scoreText.text = score.ToString().PadLeft(4,'0');
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
