using UnityEngine;

public class PanelCloser : MonoBehaviour
{
    private GameObject panel; // ������ �� ������

    void Start()
    {
        panel = transform.parent.gameObject; // �������� ������, � ������� ��������� ���� ������

        // ���������, ��� ������ ����������
        if (panel == null)
        {
            Debug.LogError("Panel not found!");
        }
    }

    public void ClosePanel()
    {
        // �������� ������
        if (panel != null)
        {
            panel.SetActive(false); // ������ ������ ����������
        }
    }
}
