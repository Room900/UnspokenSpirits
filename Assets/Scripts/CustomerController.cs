using UnityEngine;
using System.Collections;

public class CustomerController : MonoBehaviour
{
    [Header("���������")]
    public float moveSpeed = 2f;          // �������� ������
    public Transform startPoint;          // ����� ���������
    public Transform targetPoint;         // ����� � �����
    public GameObject[] drinkPrefabs;     // ������� �������� (��� ������)

    private Animator animator;
    private bool isAtBar = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        transform.position = startPoint.position; // �������� ��� ������
    }

    // ���������� ��� ����� �� ����
    public void WalkToBar()
    {
        if (!isAtBar)
        {
            StartCoroutine(MoveToBar());
        }
    }

    IEnumerator MoveToBar()
    {
        // ��� � ������
        animator.Play("WalkIn");

        while (Vector3.Distance(transform.position, targetPoint.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // ���������������
        isAtBar = true;
        animator.Play("Idle");

        // ������ ����� (���������� ������� ��� �������)
        if (drinkPrefabs.Length > 0)
        {
            int randomDrink = Random.Range(0, drinkPrefabs.Length);
            Instantiate(drinkPrefabs[randomDrink], transform.position + Vector3.up * 2, Quaternion.identity);
        }

        // ��� 5 ������ � ������
        yield return new WaitForSeconds(5f);

        animator.Play("WalkOut");
        while (Vector3.Distance(transform.position, startPoint.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        isAtBar = false;
    }
}