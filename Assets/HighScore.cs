using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
	static private Text uiText;
	static private int score = 1000;

	private Text txtCom;

	private void Awake() {
		uiText = GetComponent<Text>();

		// If the PlayerPrefs HighScore already exists, read it
		if (PlayerPrefs.HasKey("HighScore")) {
			_score = PlayerPrefs.GetInt("HighScore");
		}
		// Assign the high score to HighScore
		PlayerPrefs.SetInt("HighScore", _score);
	}

	static public int _score {
		get {
			return (score);
		}

		private set {
			score = value;
			PlayerPrefs.SetInt("HighScore", value);
			if (uiText != null) {
				uiText.text = "High Score: " + value.ToString("#,0");
			}
		}
	}

	 static public void TRY_SET_HIGH_SCORE( int scoreToTry ) {
        if (scoreToTry <= _score) return;
        _score = scoreToTry;
    }

	public bool resetHighScoreNow = false;

	void onDrawGizmos() {
        if (resetHighScoreNow) {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt( "HighScore", 1000 );
            Debug.LogWarning("PlayerPrefs HighScore reset to 1000.");
        }
    }
}
