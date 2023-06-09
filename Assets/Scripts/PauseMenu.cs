using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenuUI;

    public static bool gameIsPaused = false;

    void Update()
    {
        foreach (InputDevice device in InputSystem.devices)
        {
            if ((device is Gamepad gamepad && gamepad.startButton.wasPressedThisFrame) ||
                (device is Keyboard keyboard && keyboard.escapeKey.wasPressedThisFrame))
            {
                if (gameIsPaused) ResumeGame();
                else PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame() => Application.Quit();

    void PauseGame()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
