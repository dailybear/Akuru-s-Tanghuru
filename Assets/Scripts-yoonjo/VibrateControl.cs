using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibrateControl : MonoBehaviour
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
        {
            OnSwitch(true);
            VibrationSwitch(true);
        }
        else
        {
            OnSwitch(false);
            VibrationSwitch(false);
        }
    }

    public void OnSwitch(bool on)
    {
        if (on)
        {
            toggleImage.sprite = imageWhenOn;
            Debug.Log("Vibration On");
        }   
        else
        {
            toggleImage.sprite = imageWhenOff;
            Debug.Log("Vibration Off");
        } 
    }

    public string VibrationSwitch(bool on)
    {
        if (on)
            return "vibrate_on";

        else
            return "vibrate_off";
    }
}

