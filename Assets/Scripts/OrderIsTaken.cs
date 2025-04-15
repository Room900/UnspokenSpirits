using UnityEngine;

public class IntersectionField : MonoBehaviour
{
    public GameObject objectToHide; // ������ �� GameObject, ������� ����� ������

    void Start()
    {
        // ���������, ��� objectToHide �������� � ����������
        if (objectToHide == null)
        {
            Debug.LogError("Object to hide is not assigned! Please assign it in the Inspector.");
            enabled = false; // ��������� ������, ����� �������� ������
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���� ��� �����������, ����� ������ ��������� ������ � �������

        // �������� GameObject
        objectToHide.SetActive(false);
        Debug.Log("GameObject hidden due to collision with: " + other.gameObject.name);
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    //���� ��� �����������, ����� ��������� ������� �� ��������

    //    //���������� GameObject
    //    objectToHide.SetActive(true);
    //    Debug.Log("GameObject unhidden due to exit with: " + other.gameObject.name);
    //}
}
