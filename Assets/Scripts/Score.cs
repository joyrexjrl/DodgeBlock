using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] TextMeshProUGUI _scoreText;
    float _timer = 0;

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        _scoreText.text = _timer.ToString("0");
    }
}
