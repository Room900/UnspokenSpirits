using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSaver : MonoBehaviour
{
    private const string LAST_SCENE_KEY = "LastScene";

    // Вызываем при загрузке любой сцены (кроме главного меню)
    public static void SaveLastScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt(LAST_SCENE_KEY, currentScene);
        PlayerPrefs.Save();
    }

    // Проверяем наличие сохранения
    public static bool HasSave()
    {
        return PlayerPrefs.HasKey(LAST_SCENE_KEY);
    }

    // Загружаем сохранённую сцену
    public static void LoadSavedScene()
    {
        if (HasSave())
        {
            int sceneIndex = PlayerPrefs.GetInt(LAST_SCENE_KEY);
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogWarning("No saved scene found!");
            // Если сохранения нет - грузим первую сцену после меню
            SceneManager.LoadScene(1);
        }
    }
}