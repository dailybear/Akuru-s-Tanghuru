using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Y_ProgressBar : MonoBehaviour
{
    [SerializeField] Slider progressBar;
    [SerializeField] TextMeshProUGUI time;

    // ������ �ɸ��� �ð�
    [SerializeField] float maxTime = 30;
    // ���� �����ϱ� ���� �ð�
    private float curTime;
  

    private void OnEnable()
    {
        curTime = maxTime;
        progressBar.value = (float)curTime / (float)maxTime;
    }

    private void Update()
    {
        if (DataManager.Instance.isFruitAvaliable)
        {
            progressBar.gameObject.SetActive(true);
            curTime -= Time.deltaTime;
            time.text = (((int)curTime % 60).ToString() + "s");
            ProgressBarZero();
            HandleBar();
            
        }
        else
        {
            progressBar.gameObject.SetActive(false);
            curTime = maxTime;
        }
    }

    /// <summary>
    /// ������ �����ð��� 0�ΰ��
    /// </summary>
    private void ProgressBarZero()
    {
        if (curTime <= 0.1)
        {
            curTime = maxTime;
            progressBar.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// ��ư Ŭ���� �����ð� ����
    /// </summary>
    public void AccelateTime()
    {
        if (DataManager.Instance.isFruitAvaliable == false) return;
        curTime -= 3f;
    }

    /// <summary>
    /// Ÿ�̸� �� 
    /// </summary>
    void HandleBar()
    {
        progressBar.value = (float)curTime / ((float)maxTime);
    }

 
}
