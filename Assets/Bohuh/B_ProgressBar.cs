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
    float maxTime = 30;
    // ���� �����ϱ� ���� �ð�
    private float curTime;
    // �������ΰ���
    private bool isPrepping = true;
    private bool isSelected = false;

    private void OnEnable()
    {
        curTime =(float) maxTime;
        progressBar.value = (float)curTime / (float)maxTime;
    }

    private void Update()
    {
        if (DataManager.Instance.isFruitAvaliable ==true)
        {
            FruitSelect();
            progressBar.gameObject.SetActive(true);
            curTime -= Time.deltaTime;
            time.text = (((int)curTime % 60).ToString() + "s");
            HandleBar();
            spawnTang();
            ProgerssBarZero();
        }
        else
        {
            progressBar.gameObject.SetActive (false);
            curTime = (float)maxTime;
        }
    }

    /// <summary>
    /// ������ �����ð��� 0�ΰ��
    /// </summary>
    private void ProgerssBarZero()
    {
        if ((float)curTime <=0)
        {
            curTime = (float)maxTime;
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
            isSelected = false;
        }
    }
    void FruitSelect()
    {
        if(isSelected == false)
        {
            DataManager.Instance.SelectRandomFruit();
            maxTime = DataManager.Instance.SelectedFruitPrepTime();
            isSelected = true;
        }
    }
}
