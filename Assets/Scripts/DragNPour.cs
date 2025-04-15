using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndPour : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Vector2 _originalPosition;
    private bool isPouring = false;
    public GameObject liquid;

    // ������ �� ������ � ��������
    public Animator bottleAnimator;   // �������� �������

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        liquid.transform.localScale = new Vector3(1, 0, 1);
    }

    void Update()
    {
        // �������������� ������, ���� �����
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Check");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        _originalPosition = rectTransform.anchoredPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");

        // ������� � �������� ���������, ���� �� ���������� ���������
        rectTransform.anchoredPosition = _originalPosition;

    }

    public void OnDrag(PointerEventData eventData)
    {
        //  Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Bottle is over the cup!");
        StartPouring();

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        Debug.Log("Bottle left the cup.");
        StopPouring();

    }

    private void StartPouring()
    {
        if (!isPouring)
        {
            isPouring = true;
            bottleAnimator.SetTrigger("Pour");//������ �������� �������
            StartCoroutine(FillCup());// ������ �������� ���������

            // ����� ����� �������� �������������� �������� ������� ��� ������
        }
    }

    private void StopPouring()
    {
        if (isPouring)
        {
            isPouring = false;
            bottleAnimator.Play("Idle");
            // ���� ����������, ����� �������� ��������� �������� ��� ������ ��������
        }
    }
    private IEnumerator FillCup()
    {
        float fillAmount = 0.07f;
        liquid.transform.localScale = new Vector3(0.28f, fillAmount, 0);
        while (isPouring)
        {
         
            liquid.transform.localScale += new Vector3(0, fillAmount, 0) * Time.deltaTime;

            yield return null; // ���� �� ���������� �����

        }

    }
}
