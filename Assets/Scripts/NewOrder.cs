using System.Collections;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject characterObject; // ������ �� GameObject ���������
    public GameObject relatedObject;    // ������ �� ��������� GameObject
    public float time1;
    public float time2;
    public float time3;
    public float time4;

    void Start()
    {
        // �������� ������� �����������
        if (characterObject == null)
        {
            Debug.LogError("Character GameObject is not assigned!");
            enabled = false; // ��������� ������, ����� �������� ������
            return;
        }
        if (relatedObject == null)
        {
            Debug.LogError("Related GameObject is not assigned!");
            enabled = false; // ��������� ������, ����� �������� ������
            return;
        }

        // ��������� ��������, ������� ����� ��������� ���������� ��������� � ��������
        StartCoroutine(CharacterSequence());
    }

    IEnumerator CharacterSequence()
    {
        //yield return Input.GetMouseButtonDown(0);
        // 3 ������� ����
        yield return new WaitForSeconds(time1);

        // �������� ���������� �������
        characterObject.SetActive(true);

        // ���� 1 �������
        yield return new WaitForSeconds(time2);

        // ���������� ��������� ��������
        relatedObject.SetActive(true);

        // ���� 5 ������
        yield return new WaitForSeconds(time3);

        // ��������� �������� ���������
        relatedObject.SetActive(false);

        // ���� ��� 5 ������
        yield return new WaitForSeconds(time4);

        // �������� ���������
        characterObject.SetActive(false);

        Debug.Log("Sequence complete!");
    }
}
