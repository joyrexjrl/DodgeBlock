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

    void Start() => _currentRunScore = _scoreText;

    void Update()
    {
        _timer += Time.deltaTime;
        _scoreText.text = $"Score: {_timer:0.00}";
        _currentRunScore.text = _scoreText.text;
    }

    public void AddCurrentScoreToHighScores()
    {
        _scoresList.Add(float.Parse(_scoreText.text.Substring(7)));
        _scoresList.Sort();
        _scoresList.Reverse();
        for (int i = 0; i < _highScoresArray.Length; i++)
        {
            _highScoresArray[i].text = i < _scoresList.Count ? $"#{i + 1}: {_scoresList[i]:0.00}" : "";
        }
    }    
}
