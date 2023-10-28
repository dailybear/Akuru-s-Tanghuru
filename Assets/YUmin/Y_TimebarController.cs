using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Y_TimebarController : MonoBehaviour
{
    public Slider progressBar; // ���α׷��� �� UI ���
    public Button accelerateButton; // ���� ��ư UI ���

    private float totalTime = 30.0f; // �⺻ ��ǰ ���� �ð� (��)
    private float currentTime; // ���� ���� �ð�
    private bool isAccelerated = false; // ���� ����
    private float lastRealTime; //������ ���� �ð�
    
    public float CurrentTime
    {
        get { return currentTime; }
    }


    private void Start()
    {
        currentTime = totalTime;
        progressBar.maxValue = totalTime;
        progressBar.value = totalTime;
        progressBar.interactable = false; // ���� ��ư�� ��Ȱ��ȭ

        accelerateButton.onClick.AddListener(AccelerateProgress);

        lastRealTime = Time.realtimeSinceStartup;

        accelerateButton.onClick.AddListener(AccelerateProgress);
    }

    private void Update()
    {
        if (isAccelerated)
        {
            float realTimeNow = Time.realtimeSinceStartup;
            float deltaTime = realTimeNow - lastRealTime;
            lastRealTime = realTimeNow;

             // ���� ��ư�� ���� �� �ð��� 3�ʾ� ����
            UpdateProgressBar();
        }
    }

    private void UpdateProgressBar()
    {
        progressBar.value = currentTime;

        if (currentTime <= 0)
        {
            // ��ǰ �ϼ� ó�� �Ǵ� ���� �ܰ�� �̵�
            Debug.Log("���Ϸ�");
            ResetProgressBar();
        }
    }

    private void ResetProgressBar()
    {
        currentTime = totalTime;
        progressBar.value = totalTime;
        isAccelerated = false;
        progressBar.interactable = false;
    }

    public void AccelerateProgress()
    {
        isAccelerated = true;
        progressBar.interactable = true; // ���� ��ư�� ��Ȱ��ȭ���� �ʰ� Ȱ��ȭ
    }
}

