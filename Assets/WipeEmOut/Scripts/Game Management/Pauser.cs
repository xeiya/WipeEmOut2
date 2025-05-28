using UnityEngine;

public class Pauser : MonoBehaviour
{
    [Tooltip("The game object which should toggle on or off with the pause state")]
    public GameObject pausePanel;
    //Whether or not the game is currently paused
    private bool isPaused;

    /// <summary>
    /// Returns true if the game is paused, otherwise returns false.
    /// </summary>
    /// <returns></returns>
    public bool GetPausedState()
    {
        return isPaused;
    }

    /// <summary>
    /// Toggle whether the game is paused or not, setting the paused state and the pause screen.
    /// </summary>
    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        pausePanel.SetActive(isPaused);
    }
}
