using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public AudioSource audioSource;
    public AudioClip tapClip;
    public AudioClip rolletClip;
    public Toggle soundToggle; // �� ����� ���带 �����ϴ� �� ���˴ϴ�.


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static SoundManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public void PlayTapSound()
    {
        if (soundToggle.isOn) // ����� ���� �ִ� ��쿡�� ���� ���
        {
            audioSource.PlayOneShot(tapClip);
        }
    }

    public void playRulletSound()
    {
        if (soundToggle.isOn) // ����� ���� �ִ� ��쿡�� ���� ���
        {
            audioSource.PlayOneShot(rolletClip);
        }
    }
}
