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

    // 손질에 걸리는 시간
    [SerializeField] float maxTime = 30;
    // 현재 손질하기 남은 시간
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
    /// 손질에 남은시간이 0인경우
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
        progressBar.value = (float)curTime / ((float)maxTime);
    }

 
}
