using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] TextMeshProUGUI scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Time.deltaTime.ToString("0");
    }
}
