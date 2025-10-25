using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public Image heart;
    public GameObject endGamePopup;
    public TextMeshProUGUI finalScoreText;
    public Button backToMenuButton;

    private int _score;

    private void Start()
    {
        Time.timeScale = 1;
        backToMenuButton.onClick.AddListener(BackToMenu);
        AddScore(0);
    }

    public void AddScore(int score)
    {
        _score += score;

        string playerName = PlayerPrefs.GetString("PlayersName");
        pointsText.text = playerName + ": " + _score.ToString();
    }

    public void SetNewLife(float lives)
    {
        float percentage = lives / 3f;
        heart.fillAmount = percentage;
    }

    public void ShowEndGamePopup()
    {
        Time.timeScale = 0;
        endGamePopup.SetActive(true);
        string playerName = PlayerPrefs.GetString("PlayersName");
        finalScoreText.text = playerName + " - " + _score.ToString();
    }

    void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("ZombieMenu");
    }
}
