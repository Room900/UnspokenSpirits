using UnityEngine;
using UnityEngine.UI;

public class Open_Panel : MonoBehaviour
{
    public GameObject panel; // ���������� ���� ���� ������ � ����������
    void Start()
    {
        //panel.SetActive(false); // ������ ������ � ������
    }

    public void TogglePanel() // �����, ������� ����� ���������� ��� ������� �� ������
    {
        panel.SetActive(!panel.activeSelf);
    }
}
