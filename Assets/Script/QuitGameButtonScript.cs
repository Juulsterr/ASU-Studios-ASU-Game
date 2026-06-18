using UnityEngine;
using UnityEditor;

public class QuitGameButtonScript : MonoBehaviour
{

    public void QuitGame()
    {
        Debug.Log("QuitGame() aangeroepen!");

    #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
    #else
        Debug.Log("Quit Game");
    #endif
    }
}
