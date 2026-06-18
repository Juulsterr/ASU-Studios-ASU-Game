using UnityEngine;

public class ResumeGameScript : MonoBehaviour
{
    public GameObject PauseMenuCanvas; // Reference to the pause menu canvas
    public void ResumeGame()
    {
        Time.timeScale = 1; // Resume the game
        PauseMenuCanvas.SetActive(false); // Deactivate the pause menu when the game is resumed
    }
}
