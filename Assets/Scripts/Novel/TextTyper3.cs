using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.SceneManagement;

public class NovelTextSystem2 : MonoBehaviour
{
    [Header("Characters")]
    public GameObject[] characters; // characters[0] - Карина, characters[1] - Влад
    public float inactiveCharacterAlpha = 0.5f; // Прозрачность когда не говорит
    private Image[] characterImages;
    private int currentSpeaker = -1; // Текущий говорящий (-1 - никто)

    [Header("UI References")]
    public TMP_Text dialogueText;
    public TMP_Text nameText;
    public GameObject choiceButtonPanel;
    public Button choiceButtonPrefab;
    public GameObject txtObj;
    public GameObject ToBar;

    [Header("Background Settings")]
    public GameObject[] backgroundImages; // Массив фоновых изображений
    public GameObject final_back;
    private CanvasGroup[] backgroundCanvasGroups;
    private int currentBackgroundIndex = 0;
    public float backgroundFadeDuration = 1f;

    [Header("INK File")]
    public TextAsset inkJSONAsset;

    [Header("Settings")]
    public float typeSpeed = 0.05f;

    private Story currentStory;
    private bool isTyping = false;
    private bool isChoosing = false;

    void Start()
    {
        InitializeCharacters();
        InitializeBackgrounds();

        currentStory = new Story(inkJSONAsset.text);

        choiceButtonPanel.SetActive(false);

        ContinueStory();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = currentStory.currentText;
                isTyping = false;
            }
            else if (!isChoosing)
            {
                ContinueStory();
            }
        }
    }

    void UpdateCharacterVisibility(int speakerIndex)
    {
        // Сначала скрываем всех персонажей
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
        }

        // Если это авторский текст (-1), просто выходим
        if (speakerIndex == -1)
        {
            currentSpeaker = -1;
            return;
        }

        // Активируем нужного персонажа
        currentSpeaker = speakerIndex;
        characters[speakerIndex].SetActive(true);

        // Устанавливаем прозрачность
        if (characterImages[speakerIndex] != null)
        {
            Color c = characterImages[speakerIndex].color;
            c.a = 1f; // Всегда полностью видимый когда говорит
            characterImages[speakerIndex].color = c;
        }
    }

    void InitializeCharacters()
    {
        characterImages = new Image[characters.Length];

        for (int i = 0; i < characters.Length; i++)
        {
            characterImages[i] = characters[i].GetComponent<Image>();
            if (characterImages[i] != null)
            {
                Color c = characterImages[i].color;
                c.a = 0; // Начинаем с полностью прозрачных
                characterImages[i].color = c;
            }
            characters[i].SetActive(false);
        }
        currentSpeaker = -1;
    }

    void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            string text = currentStory.Continue();

            // Обработка тегов
            bool hasCharacterTag = false;
            if (currentStory.currentTags.Count > 0)
            {
                foreach (string tag in currentStory.currentTags)
                {
                    if (tag.StartsWith("BG_"))
                    {
                        string bgIndexStr = tag.Replace("BG_", "");
                        if (int.TryParse(bgIndexStr, out int newBgIndex))
                        {
                            StartCoroutine(ChangeBackground(newBgIndex));
                        }
                    }
                    else if (tag.StartsWith("CHAR_"))
                    {
                        string charIndexStr = tag.Replace("CHAR_", "");
                        if (int.TryParse(charIndexStr, out int charIndex))
                        {
                            UpdateCharacterVisibility(charIndex);
                            hasCharacterTag = true;
                        }
                    }
                    else if (tag == "AUTHOR_TEXT")
                    {
                        UpdateCharacterVisibility(-1);
                    }
                }
            }

            // Если нет тега персонажа, но был активный - скрываем
            if (!hasCharacterTag && currentSpeaker != -1)
            {
                UpdateCharacterVisibility(-1);
            }

            // Установка имени персонажа
            if (currentStory.variablesState["characterName"] != null)
            {
                nameText.text = (string)currentStory.variablesState["characterName"];
            }
            else
            {
                nameText.text = "";
            }

            StartCoroutine(TypeText(text));

            if (currentStory.currentChoices.Count > 0)
            {
                StartCoroutine(ShowChoices());
            }
        }
        else
        {
            Debug.Log("End of story");
            backgroundImages[currentBackgroundIndex].SetActive(false);
            final_back.SetActive(true);
            txtObj.SetActive(false);
            ToBar.SetActive(true);
        }
    }

    void InitializeBackgrounds()
    {
        backgroundCanvasGroups = new CanvasGroup[backgroundImages.Length];

        for (int i = 0; i < backgroundImages.Length; i++)
        {
            // Добавляем CanvasGroup если нет
            var canvasGroup = backgroundImages[i].GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = backgroundImages[i].AddComponent<CanvasGroup>();
            }

            backgroundCanvasGroups[i] = canvasGroup;
            backgroundImages[i].SetActive(i == 0); // Активируем только первый фон
            canvasGroup.alpha = i == 0 ? 1 : 0;    // Делаем видимым только первый фон
        }
    }

    IEnumerator ChangeBackground(int newIndex)
    {
        Debug.Log($"Attempting to change background to index: {newIndex}");
        if (newIndex < 0 || newIndex >= backgroundImages.Length)
        {
            Debug.LogError("Invalid background index: " + newIndex);
            yield break;
        }

        // Не меняем фон, если он уже активен
        if (newIndex == currentBackgroundIndex)
        {
            Debug.Log("Background already active: " + newIndex);
            yield break;
        }

        // Активируем новый фон
        Debug.Log($"Activating background: {newIndex}");
        backgroundImages[newIndex].SetActive(true);
        CanvasGroup currentBG = backgroundCanvasGroups[currentBackgroundIndex];
        CanvasGroup nextBG = backgroundCanvasGroups[newIndex];

        float timer = 0;
        while (timer < backgroundFadeDuration)
        {
            timer += Time.deltaTime;
            float progress = timer / backgroundFadeDuration;

            currentBG.alpha = 1 - progress;
            nextBG.alpha = progress;
            yield return null;
        }

        // Деактивируем старый фон только после завершения анимации
        backgroundImages[currentBackgroundIndex].SetActive(false);
        currentBackgroundIndex = newIndex;
    }

    IEnumerator TypeText(string text)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in text)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }

        isTyping = false;
    }

    IEnumerator ShowChoices()
    {
        isChoosing = true;
        choiceButtonPanel.SetActive(true);

        // Очистка старых кнопок
        foreach (Transform child in choiceButtonPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // Создание новых кнопок
        for (int i = 0; i < currentStory.currentChoices.Count; i++)
        {
            Choice choice = currentStory.currentChoices[i];
            Button button = Instantiate(choiceButtonPrefab, choiceButtonPanel.transform);

            // Настройка текста
            TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();
            if (buttonText != null)
            {
                buttonText.text = choice.text;
            }
            else
            {
                Debug.LogError("No TMP_Text component in button prefab!");
            }

            // Настройка обработчика клика
            int choiceIndex = i;
            button.onClick.RemoveAllListeners(); // Очищаем старые обработчики
            button.onClick.AddListener(() => StartCoroutine(MakeChoiceCoroutine(choiceIndex)));
        }

        yield return null;
    }

    IEnumerator MakeChoiceCoroutine(int choiceIndex)
    {
        // Выбираем вариант
        currentStory.ChooseChoiceIndex(choiceIndex);

        // Скрываем панель выбора
        choiceButtonPanel.SetActive(false);
        isChoosing = false;

        // Продолжаем историю
        ContinueStory();
        yield return null;
    }
}