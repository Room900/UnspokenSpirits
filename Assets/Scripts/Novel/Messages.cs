using System.Collections;
using TMPro;
using UnityEngine;

public class SequenceController : MonoBehaviour
{
    public GameObject firstGameObject;
    public GameObject secondGameObject;
    public GameObject thirdGameObject;
    public GameObject panelToClose;

    private bool waitingForInput = false;

    public GameObject textBlockToShow; // ��������� ������ �� ��������� ����


    void Start()
    {
        // ��������� ������������������
        StartCoroutine(ControlSequence());
    }

    IEnumerator ControlSequence()
    {
        // ��������� �� null ������ �� �������
        if (firstGameObject == null || secondGameObject == null || thirdGameObject == null || panelToClose == null)
        {
            Debug.LogError("���������, ��� ��� ������� ��������� � ����������!");
            yield break; // ���������� ���������� ��������
        }

        // ��������� ��� ������� � ������
        firstGameObject.SetActive(false);
        secondGameObject.SetActive(false);
        thirdGameObject.SetActive(false);

        // �������� ������ ������ ����� �������� �����
        yield return new WaitForSeconds(1.5f);
        firstGameObject.SetActive(true);

        // �������� ������ ������ ����� �������� ����� ����� ��������� �������
        yield return new WaitForSeconds(3.5f);
        secondGameObject.SetActive(true);

        // ���� �������, ����� ��������� ������ � ������ �������
        yield return new WaitForSeconds(17.0f);
        firstGameObject.SetActive(false);
        secondGameObject.SetActive(false);

        // �������� ������ ������
        thirdGameObject.SetActive(true);

        // �������� ������� ������� ����� ������ ����
        //waitingForInput = true;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0)); // ����, ���� �� ����� ������ ����� ������ ����

        // ����� ������ ������, ��������� ������
        panelToClose.SetActive(false);
        textBlockToShow.SetActive(true);

        waitingForInput = false;
        Debug.Log("������������������ ���������.");
    }

    void Update()
    {
        // ��������� ������� ������ ������ ���� �� ��������� � ��������� �������� �����
        if (waitingForInput && Input.GetMouseButtonDown(0))
        {
            // ��� ��� �������� ������ ��� ��������� � �������� ControlSequence, ������� ����� ������ �� ����� ������.
            // �������� WaitUntil ���� ��������� ������� ������ � ��������� ����������.
        }
    }
}
