using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] float _slowness = 10f;

    bool gameHasEnded = false;

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            StartCoroutine(RestartLevel());
        }
    }

    void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    IEnumerator RestartLevel()
    {
        Time.timeScale = 1f / _slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / _slowness;
        yield return new WaitForSeconds(1f / _slowness);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * _slowness;
        Restart();
    }
    
}
