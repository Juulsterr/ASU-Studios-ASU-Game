using UnityEngine;

public class PauseScreenScript : MonoBehaviour
{
    public GameObject PauseMenuCanvas;
    private bool isPaused;

    void Start()
    {
        PauseMenuCanvas.SetActive(false);
        isPaused = false;
        Debug.Log("Game gestart!");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
            {
                Time.timeScale = 0;
                PauseMenuCanvas.SetActive(true);
                isPaused = true;
                Debug.Log("Game gepauzeerd!");
            }
            else
            {
                Time.timeScale = 1;
                PauseMenuCanvas.SetActive(false);
                isPaused = false;
                Debug.Log("Game hervat!");
            }
        }
    }
}