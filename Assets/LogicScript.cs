using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEditor.PackageManager;
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public bool endOfGame = false;
    public AudioSource audioSourceDing;
    public AudioSource audioSourceGameOver;
    public AudioSource audioSourceBackground;
    public int highScore;
    public Text highScoreText;

    void Start() {
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd) {
        if (!endOfGame) {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
            audioSourceDing.Play();
        }
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver() {
        gameOverScreen.SetActive(true);
        if (playerScore > highScore) {
            highScore = playerScore;
            PlayerPrefs.SetInt("highScore", highScore);
            highScoreText.text = "High Score: " + highScore.ToString();
        }
        endOfGame = true;
        audioSourceBackground.Stop();
        audioSourceGameOver.Play();
    }
}
