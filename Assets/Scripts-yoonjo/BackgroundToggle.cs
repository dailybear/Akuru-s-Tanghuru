using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundToggle : MonoBehaviour
{
    [SerializeField] Image toggleImage; // Image ������Ʈ�� �ִ� UI ��Ҹ� ���⿡ �Ҵ��ؾ� �մϴ�.
    public Sprite imageWhenOn; // ����� ���� ���¿��� ������ �̹���
    public Sprite imageWhenOff; // ����� ���� ���¿��� ������ �̹���
    public AudioSource backgroundMusic; // ������� AudioSource

    Toggle toggle;

    void Awake()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnSwitch);

        if (toggle.isOn)
            OnSwitch(true);
        else
            OnSwitch(false);
    }

    public void OnSwitch(bool on)
    {
        if (on)
        {
            toggleImage.sprite = imageWhenOn;
            // ��������� �մϴ�.
            if (backgroundMusic != null)
            {
                backgroundMusic.Play();
            }
        }
        else
        {
            toggleImage.sprite = imageWhenOff;
            // ��������� ���ϴ�.
            if (backgroundMusic != null)
            {
                backgroundMusic.Stop();
            }
        }
    }
}

