using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAutoSaver : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Ќе сохран€ем при первой загрузке меню
        if (SceneManager.GetActiveScene().buildIndex == 0)
            return;

        PlayerPrefs.SetInt("LastScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
        Debug.Log($"Saved scene: {SceneManager.GetActiveScene().name} (index: {SceneManager.GetActiveScene().buildIndex})");
    }
}