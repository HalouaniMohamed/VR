using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI snowballCounterText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI loseText;

    private float timeRemaining = 120f;
    private int snowballHits = 0;
    private bool timerRunning = false;
    public GameController gameController;

    private void Start()
    {
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);
    }
    public void StartGameUI()
    {
        timerRunning = true;
        timeRemaining = 120f;
        snowballHits = 0;
        UpdateUI();
    }

    void Update()
    {
        if (timerRunning)
        {
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateUI();

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                timerRunning = false;
                gameController.EndGame();
                StartCoroutine(DisplayLoseMessage());
                //SceneManager.LoadScene("Complete Scene - Winter Village");

            }
        }
    }


    private void UpdateUI()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = $"Time Remaining: {minutes:00}:{seconds:00}";
        snowballCounterText.text = $"Hits: {snowballHits}/5";
    }

    public void RegisterSnowballHit()
    {
        if (snowballHits < 5)
        {
            snowballHits++;
            UpdateUI();

            if (snowballHits >= 5)
            {
                timerRunning = false;
                gameController.EndGame();
                StartCoroutine(DisplayWinMessage());
            }
        }
    }

    public void StopGameUI()
    {
        timerRunning = false;
    }

    private IEnumerator DisplayLoseMessage()
    {
        loseText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        ResetScene();
    }

    private void ResetScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Complete Scene - Winter Village");
    }

    private IEnumerator DisplayWinMessage()
    {
        winText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        ResetScene();
    }
}
