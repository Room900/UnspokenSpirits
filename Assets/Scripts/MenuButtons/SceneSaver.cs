using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSaver : MonoBehaviour
{
    private const string LAST_SCENE_KEY = "LastScene";

    public static void SaveCurrentScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Не сохраняем главное меню (индекс 0)
        if (currentSceneIndex > 0)
        {
            PlayerPrefs.SetInt(LAST_SCENE_KEY, currentSceneIndex);
            PlayerPrefs.Save();
            Debug.Log($"Manually saved scene index: {currentSceneIndex}");
        }
    }

    public static bool HasSave()
    {
        if (PlayerPrefs.HasKey(LAST_SCENE_KEY))
        {
            int savedIndex = PlayerPrefs.GetInt(LAST_SCENE_KEY);
            // Проверяем, что сохраненный индекс существует в Build Settings
            return savedIndex > 0 && savedIndex < SceneManager.sceneCountInBuildSettings;
        }
        return false;
    }

    public static void LoadSavedScene()
    {
        if (HasSave())
        {
            int sceneIndex = PlayerPrefs.GetInt(LAST_SCENE_KEY);
            Debug.Log($"Loading saved scene index: {sceneIndex}");
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogWarning("No valid saved scene found! Loading default (scene 1)");
            SceneManager.LoadScene(1); // Первая сцена после главного меню
        }
    }

    public static void ClearSave()
    {
        PlayerPrefs.DeleteKey(LAST_SCENE_KEY);
        PlayerPrefs.Save();
    }
}