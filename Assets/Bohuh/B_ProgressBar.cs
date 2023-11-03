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

    // 손질에 걸리는 시간
    [SerializeField] float maxTime;
    // 현재 손질하기 남은 시간
    private float curTime;
    // 손질중인가요
    private bool isPrepping = true;


    private void OnEnable()
    {
        if(DataManager.Instance.selectedFruit == FruitType.Strawberry || DataManager.Instance.selectedFruit == FruitType.Grape)
        {
            maxTime = 30;
        }
        else
        {
            maxTime = 36;
        }
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
    /// 손질에 남은시간이 0인경우
    /// </summary>
    private void ProgerssBarZero()
    {
        if (curTime <= 0.1)
        {
            if (DataManager.Instance.selectedFruit == FruitType.Strawberry || DataManager.Instance.selectedFruit == FruitType.Grape)
            {
                maxTime = 30;
            }
            else
            {
                maxTime = 36;
            }
            curTime = maxTime;
            isPrepping = false;
            progressBar.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 버튼 클릭시 손질시간 감소
    /// </summary>
    public void AccelateTime()
    {
        if (DataManager.Instance.isFruitAvaliable == false) return;
        curTime -= 3f;
    }

    /// <summary>
    /// 타이머 바 
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
