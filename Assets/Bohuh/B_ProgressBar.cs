using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class B_ProgressBar : MonoBehaviour
{
    [SerializeField] Slider progressBar;
    [SerializeField] TextMeshProUGUI time;

    // ������ �ɸ��� �ð�
    [SerializeField] float maxTime = 4;
    // ���� �����ϱ� ���� �ð�
    private float curTime;
    // �������ΰ���
    private bool isPrepping = true;


    private void OnEnable()
    {
        curTime = maxTime;
        progressBar.value = (float)curTime / (float)maxTime;
    }

    private void Update()
    {
        if(DataManager.Instance.isFruitAvaliable ==true)
        {
            progressBar.gameObject.SetActive(true);
            curTime -= Time.deltaTime;
            time.text = (((int)curTime % 60).ToString() + "s");
            ProgerssBarZero();
            HandleBar();
            spawnTang();
        }
        else
        {
            progressBar.gameObject.SetActive (false);
            curTime = maxTime;
        }
    }

    /// <summary>
    /// ������ �����ð��� 0�ΰ��
    /// </summary>
    private void ProgerssBarZero()
    {
        if (curTime <= 0.1)
        {
            curTime = maxTime;
            isPrepping = false;
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
        progressBar.value = (float) curTime / ((float) maxTime);
    }

    void spawnTang()
    {
        if(isPrepping == false)
        {
            FindAnyObjectByType<B_Spawnner>().Spawn();
            isPrepping = true;
        }
    }
}
