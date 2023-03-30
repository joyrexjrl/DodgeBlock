using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] float _slowness = 10f;
    [SerializeField] GameObject _gameOverMenu;
    [SerializeField] TextMeshProUGUI _currentScore;
    [SerializeField] Score _score;

    bool gameHasEnded = false;
    float _currentScoreForCurrency;

    public static event Action OnPlayerDeath;
    public float CurrentScoreForCurrency
    {
        get => _currentScoreForCurrency;
        set
        {
            _currentScoreForCurrency = value;
            PlayerPrefs.SetFloat("currentScoreForCurrency", value);
            PlayerPrefs.Save();
        }
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("currentScoreForCurrency"))
        {
            CurrentScoreForCurrency = PlayerPrefs.GetFloat("currentScoreForCurrency");
        }
        else
        {
            CurrentScoreForCurrency = 0f;
        }
    }

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            StartCoroutine(SlowTime());            
        }
    }

    void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    IEnumerator SlowTime()
    {
        Time.timeScale = 1f / _slowness;
        Time.fixedDeltaTime /= _slowness;
        yield return new WaitForSeconds(1f / _slowness);
        Time.timeScale = 1f;
        Time.fixedDeltaTime *= _slowness;
        Time.timeScale = 0f;
        OnPlayerDeath?.Invoke();        
    }

    void OnEnable() => OnPlayerDeath += EnableGameOverMenu;

    void OnDisable()
    {
        OnPlayerDeath -= EnableGameOverMenu;
        Time.timeScale = 1f;
    }

    public void EnableGameOverMenu()
    {
        _gameOverMenu.SetActive(true);
        _score.AddCurrentScoreToHighScores();
        _score.gameObject.SetActive(false);
        float currentScoreValue = _score.CurrentScore;
        _currentScore.text = $"Score for this run: {_score.CurrentScore:0.00}";
        CurrentScoreForCurrency += currentScoreValue;
        Debug.Log($"current total points earned through gameplay: {CurrentScoreForCurrency}");
    }

    public void QuitGame() => Application.Quit();

    public void RestartGame()
    {
        _gameOverMenu.SetActive(false);
        Restart();
    }
}
