using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAutoSaver : MonoBehaviour
{
    private void Awake()
    {
        // Делаем объект неуничтожаемым при загрузке новых сцен
        DontDestroyOnLoad(gameObject);

        // Подписываемся на событие изменения активной сцены
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    private void OnActiveSceneChanged(Scene previousScene, Scene newScene)
    {
        // Сохраняем только если предыдущая сцена НЕ главное меню (индекс 0)
        if (previousScene.buildIndex > 0)
        {
            PlayerPrefs.SetInt("LastScene", previousScene.buildIndex);
            PlayerPrefs.Save();

            // Для отладки (можно удалить после тестов)
            Debug.Log($"Автосохранение: сцена {previousScene.name} (индекс: {previousScene.buildIndex})");
        }
    }

    private void OnDestroy()
    {
        // Отписываемся от события при уничтожении объекта
        SceneManager.activeSceneChanged -= OnActiveSceneChanged;
    }
}