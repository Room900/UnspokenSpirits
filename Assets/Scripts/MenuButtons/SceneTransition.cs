using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // Публичное поле для назначения сцены в инспекторе
    [SerializeField] private int targetSceneIndex;

    // Старый метод для скриптового вызова
    public static void ChangeScene(int sceneIndex)
    {
        SaveCurrentScene();
        SceneManager.LoadScene(sceneIndex);
    }

    // Новый метод для вызова через UI
    public void ChangeToTargetScene()
    {
        SaveCurrentScene();
        SceneManager.LoadScene(targetSceneIndex);
    }

    private static void SaveCurrentScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex > 0) // Не сохраняем главное меню
        {
            PlayerPrefs.SetInt("LastScene", currentSceneIndex);
            PlayerPrefs.Save();
            Debug.Log($"Сохранено: сцена {currentSceneIndex}");
        }
    }
}