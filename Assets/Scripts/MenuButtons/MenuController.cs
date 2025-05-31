using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [Header("Кнопки")]
    [SerializeField] private Button continueButton;
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        // Проверка ссылок
        if (continueButton == null) Debug.LogError("ContinueButton not assigned!");
        if (newGameButton == null) Debug.LogError("NewGameButton not assigned!");
        if (quitButton == null) Debug.LogError("QuitButton not assigned!");

        // Подписываем кнопки
        continueButton?.onClick.AddListener(OnContinue);
        newGameButton?.onClick.AddListener(OnNewGame);
        quitButton?.onClick.AddListener(OnQuit);

        UpdateContinueButton();
    }

    private void UpdateContinueButton()
    {
        bool hasValidSave = CheckSaveValidity();
        if (continueButton != null)
        {
            continueButton.interactable = hasValidSave;
            Debug.Log($"Continue button active: {hasValidSave}");
        }
    }

    private bool CheckSaveValidity()
    {
        if (!PlayerPrefs.HasKey("LastScene"))
        {
            Debug.Log("No save key found");
            return false;
        }

        int savedIndex = PlayerPrefs.GetInt("LastScene");
        bool isValid = savedIndex > 0 && savedIndex < SceneManager.sceneCountInBuildSettings;

        Debug.Log($"Save validation: Index={savedIndex}, IsValid={isValid}, CurrentScenes={SceneManager.sceneCountInBuildSettings}");
        return isValid;
    }

    public void OnContinue()
    {
        if (CheckSaveValidity())
        {
            int sceneIndex = PlayerPrefs.GetInt("LastScene");
            Debug.Log($"Loading scene: {sceneIndex}");
            SceneTransition.ChangeScene(sceneIndex);
        }
    }

    public void OnNewGame()
    {
        Debug.Log("Starting new game...");
        PlayerPrefs.DeleteKey("LastScene");
        SceneTransition.ChangeScene(1); // Первая игровая сцена
    }

    public void OnQuit()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}