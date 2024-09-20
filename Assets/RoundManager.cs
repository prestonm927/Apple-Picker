using UnityEngine;
using TMPro;  // Import TextMeshPro namespace
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    public TextMeshProUGUI roundText;  // Reference to the TextMeshPro object
    private int currentRound = 1;
    private int maxRounds = 4;
    private bool gameOver = false;

    public GameObject restartButton;

    void Start()
    {
        restartButton.SetActive(false);
        UpdateRoundText();  // Display "Round 1" at start
    }

    // Function to move to the next round
    public void NextRound()
    {
        if (!gameOver)
        {
            currentRound++;

            if (currentRound > maxRounds)
            {
                GameOver();  // End game when rounds exceed maxRounds
            }
            else
            {
                UpdateRoundText();
            }
        }
    }

    // Function to update the round text
    public void UpdateRoundText()
    {
        roundText.text = "Round " + currentRound;
    }

    // Function to handle Game Over
    public void GameOver()
    {
        gameOver = true;
        roundText.text = "Game Over";
        restartButton.SetActive(true);
    }

    // Function to restart the game (called by the restart button)
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reloads the current scene
    }
}
