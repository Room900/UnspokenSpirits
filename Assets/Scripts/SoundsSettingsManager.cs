using UnityEngine;
using UnityEngine.UI;

public class SoundSettingsManager : MonoBehaviour
{
    public GameObject settingsPanel; // ������ �� ������ ��������
    public Slider volumeSlider; // ������ �� ������� ���������

    void Start()
    {
        // ������� �������� ������
        settingsPanel.SetActive(false);

        // ������������� ��������� �������� ���������
        volumeSlider.value = AudioListener.volume;

        // ��������� ���������� ��������� �������� ��������
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // ����� ��� ��������/�������� ������
    public void ToggleSettingsPanel()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    // ����� ��� ��������� ���������
    private void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}