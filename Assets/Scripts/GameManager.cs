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

    public static event Action OnPlayerDeath;

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

    void OnEnable()
    {
        OnPlayerDeath += EnableGameOverMenu;       
    }

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
        _currentScore.text = $"Score for this run: {_score.CurrentScore:0.00}";
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        _gameOverMenu.SetActive(false);
        Restart();
    }
}
