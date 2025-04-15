using System.Collections;
using UnityEngine;
using TMPro;

public class TextTyperTMP : MonoBehaviour
{
    public TMP_Text textComponent; // ������ �� ��������� TextMeshPro Text
    public string fullText; // �����, ������� ����� ������� �����������
    public float typeSpeed = 0.05f; // �������� ����� ������� ��������

    private string currentText = ""; // ������� ������������ �����
    private bool isTyping = false; // ����, ������������, ���� �� ������ ����� ������

    void Start()
    {
        // ���������, ��� textComponent ��������
        if (textComponent == null)
        {
            Debug.LogError("TextMeshPro Text Component �� ��������! ����������, ���������� ��������� TextMeshPro Text � ���� Text Component � Inspector.");
            enabled = false; // ��������� ������, ����� �� ���� ������
            return;
        }

        // ��������� �������� ��� ������ ������ �����������
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        isTyping = true;
        currentText = ""; // �������� � ������� ������
        textComponent.text = currentText; // ��������� TextMeshPro Text

        // ���������� �� ������� ������� � fullText
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText += fullText[i]; // ��������� ������� ������ � ������������� ������
            textComponent.text = currentText; // ��������� TextMeshPro Text
            yield return new WaitForSeconds(typeSpeed); // ���� ��������� �����
        }

        isTyping = false; // ������������� ����, ��� ����� ������ ��������
    }

    // (�������������) ������� ��� ����������� ���������� ������ ������ ��� ������� ������
    public void SkipTyping()
    {
        if (isTyping)
        {
            StopCoroutine(TypeText()); // ������������� �������� TypeText
            textComponent.text = fullText; // ���������� ���� ����� �����
            isTyping = false;
        }
    }
}
