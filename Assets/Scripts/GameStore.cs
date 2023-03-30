using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStore : MonoBehaviour
{
    public void PlayGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}
