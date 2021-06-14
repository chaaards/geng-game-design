using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GenerationGirl
{
	public class GameManager : MonoBehaviour
	{
		public static GameManager instance;
		private int score;

		public Bird bird;
		public Text scoreText;
		public Text highScoreText;
		public GameObject gameOverPanel;

		public bool isGameOver;

		private string highScoreKey = "hiscoreKey";

		private void Awake()
		{
			if (instance == null)
				instance = this;
			else if (instance != this)
				Destroy(gameObject);

			score = 0;
			isGameOver = false;
			scoreText.gameObject.SetActive(true);
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0) && isGameOver)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}

		public void UpdateScore()
		{
			if (isGameOver)
				return;

			score++;
			scoreText.text = score.ToString();

		}

		public void MarkAsGameOver()
		{
			isGameOver = true;
			scoreText.gameObject.SetActive(false);
			gameOverPanel.SetActive(true);
			SaveHighScore(score);
			highScoreText.text = LoadHighScore().ToString();
		}

		private void SaveHighScore(int score)
		{
			if (score > LoadHighScore())
			{
				PlayerPrefs.SetInt(highScoreKey, score);
			}
		}

		private int LoadHighScore()
		{
			if (PlayerPrefs.HasKey(highScoreKey))
			{
				return PlayerPrefs.GetInt(highScoreKey);
			}
			else
			{
				return 0;
			}
		}
	}
}
