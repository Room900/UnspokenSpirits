using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
    #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
    #else
                Application.Quit();
    #endif
    }
}
