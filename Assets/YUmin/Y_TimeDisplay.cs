using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Y_TimeDisplay : MonoBehaviour
{
    public TextMeshProUGUI timeText;   //text ui ���
    public Y_TimebarController progressBarController;


    void Update()
    {
        //���� �ð��� �ؽ�Ʈ�� ǥ��
        float currentTime = progressBarController.CurrentTime;
        int timeInSeconds = Mathf.FloorToInt(currentTime);  //�� ������ ��ȯ
        timeText.text = timeInSeconds + "s";
    }
}
