using UnityEngine;
using UnityEngine.EventSystems; // ����������� ��� ������ � UI Event System
using UnityEngine.UI;

public class ClosePanelOnClickOutside : MonoBehaviour, IPointerClickHandler
{
    public GameObject panel; // ������ �� ������, ������� ����� ���������

    public void OnPointerClick(PointerEventData eventData)
    {
        // ���������, ��� �� ���� ������ ������
        RectTransform panelRectTransform = panel.GetComponent<RectTransform>();
        if (panelRectTransform != null && RectTransformUtility.RectangleContainsScreenPoint(panelRectTransform, eventData.position, eventData.enterEventCamera))
        {
            // ���� ��� ������ ������, ������ �� ������
            return;
        }

        // ���� ��� �� ��������� ������, ��������� ������
        panel.SetActive(false);
    }
}
