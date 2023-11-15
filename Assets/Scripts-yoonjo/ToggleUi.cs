using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleUi : MonoBehaviour
{
    [SerializeField] Image toggleImage; // Image ������Ʈ�� �ִ� UI ��Ҹ� ���⿡ �Ҵ��ؾ� �մϴ�.
    public Sprite imageWhenOn; // ����� ���� ���¿��� ������ �̹���
    public Sprite imageWhenOff; // ����� ���� ���¿��� ������ �̹���

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
            toggleImage.sprite = imageWhenOn;

        else
            toggleImage.sprite = imageWhenOff;
    }
}