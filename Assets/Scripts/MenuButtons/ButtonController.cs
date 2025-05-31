using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Button continueButton; // Ссылка на кнопку "Продолжить"

    private void Start()
    {
        Debug.Log("Есть сохранение? " + PlayerPrefs.HasKey("LastScene"));
        Debug.Log("Индекс последней сцены: " + PlayerPrefs.GetInt("LastScene"));

        if (continueButton != null)
        {
            continueButton.interactable = PlayerPrefs.HasKey("LastScene");
        }
    }
    //private void Start()
    //{
    //    // Делаем кнопку "Продолжить" активной только если есть сохранение
    //    if (continueButton != null)
    //    {
    //        continueButton.interactable = SceneSaver.HasSave();
    //    }
    //}

    public void NewGameButton()
    {
        // При запуске новой игры сбросим сохранение (опционально)
        PlayerPrefs.DeleteKey("LastScene");
        SceneManager.LoadScene(1);
    }

    public void ContinueButton()
    {
        // Загружаем последнюю сохранённую сцену
        SceneSaver.LoadSavedScene();
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}