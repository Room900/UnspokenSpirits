using UnityEngine;
using UnityEngine.UI; // ����������� �������� ��� ������������ ����

public class ImageSpriteChanger : MonoBehaviour
{
    public Sprite[] sprites; // ������ �������� ��� �����
    public float frameRate = 0.25f; // �������� ����� ������ (�������� � ��������)

    private Image image;
    private int currentSpriteIndex = 0;
    private float timer = 0f;

    void Start()
    {
        image = GetComponent<Image>();
        if (image == null)
        {
            Debug.LogError("��������� Image �� ������!");
            enabled = false; // ��������� ������, ���� ��� ���������� Image
            return;
        }
        if (sprites == null || sprites.Length == 0)
        {
            Debug.LogError("�� �������� ������ ��������!");
            enabled = false; // ��������� ������, ���� ��� ��������
            return;
        }
        image.sprite = sprites[0]; // ������������� ������ ������
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= frameRate)
        {
            timer -= frameRate;
            ChangeSprite();
        }
    }

    void ChangeSprite()
    {
        currentSpriteIndex++;
        if (currentSpriteIndex >= sprites.Length)
        {
            currentSpriteIndex = 0; // ������������ � ������� �������
        }
        image.sprite = sprites[currentSpriteIndex];
    }

    // ������ �������������: �������� ChangeSprite() �� ������ ����� ������ ����,
    // ��������, �� ������� ������.
}
