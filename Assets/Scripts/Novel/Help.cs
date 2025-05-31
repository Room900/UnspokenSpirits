using UnityEngine;
using UnityEngine.SceneManagement;

public class Helper : MonoBehaviour
{
    [Header("Настройки активации")]
    [SerializeField] private GameObject[] objects; // Объекты для поочередной активации

    private int currentIndex = 0; // Индекс текущего объекта

    private void Start()
    {
        // Деактивируем все объекты при старте
        foreach (var obj in objects)
        {
            if (obj != null)
                obj.SetActive(false);
        }
    }

    private void Update()
    {
        // Проверяем нажатие ЛКМ
        if (Input.GetMouseButtonDown(0))
        {
            ActivateNextObject();
        }
    }

    private void ActivateNextObject()
    {
        // Если есть еще объекты для активации
        if (currentIndex < objects.Length)
        {
            // Активируем текущий объект
            if (objects[currentIndex] != null)
            {
                objects[currentIndex].SetActive(true);
            }
            currentIndex++;
        }
        else
        {
            // Все объекты активированы - переходим на следующую сцену
            SceneTransition.ChangeScene(2);
        }
    }
}