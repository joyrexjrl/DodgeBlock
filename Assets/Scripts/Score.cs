using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] TextMeshProUGUI scoreText;
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        scoreText.text = timer.ToString("0");
    }
}
