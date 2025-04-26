using UnityEngine;
using UnityEngine.UI;

public class PanelOpener : MonoBehaviour
{
    public GameObject panel; // ���������� ���� ���� ������ � ����������
    void Start()
    {
        panel.SetActive(false); // ������ ������ � ������
    }

    public void OpenPanel() // �����, ������� ����� ���������� ��� ������� �� ������
    {
        panel.SetActive(true);
    }
}
