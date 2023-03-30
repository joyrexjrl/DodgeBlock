using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Score : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] TextMeshProUGUI _currentRunScore;
    [SerializeField] TextMeshProUGUI[] _highScoresArray;

    float _timer = 0;

    List<float> _scoresList = new();

    public float CurrentScore { get { return float.Parse(_currentRunScore.text.Substring(7)); } }

    void Start()
    {
        _currentRunScore = _scoreText;

        for (int i = 0; i < _highScoresArray.Length; i++)
        {
            if (PlayerPrefs.HasKey($"highscore{i}"))
            {
                float score = PlayerPrefs.GetFloat($"highscore{i}");
                _scoresList.Add(score);
                _highScoresArray[i].text = $"#{i + 1}: {score:0.00}";
            }
            else _highScoresArray[i].text = "";
        }
    }

    void Update()
    {
        _timer += Time.deltaTime;
        _scoreText.text = $"Score: {_timer:0.00}";
        _currentRunScore.text = _scoreText.text;
    }

    public void AddCurrentScoreToHighScores()
    {
        _scoresList.Add(CurrentScore);
        _scoresList.Sort();
        _scoresList.Reverse();

        // Save the high scores into PlayerPrefs
        for (int i = 0; i < _highScoresArray.Length; i++)
        {
            if (i < _scoresList.Count)
            {
                float score = _scoresList[i];
                PlayerPrefs.SetFloat($"highscore{i}", score);
                _highScoresArray[i].text = $"#{i + 1}: {score:0.00}";
            }
            else
            {
                PlayerPrefs.DeleteKey($"highscore{i}");
                _highScoresArray[i].text = "";
            }
        }
        PlayerPrefs.Save();
    }    
}
