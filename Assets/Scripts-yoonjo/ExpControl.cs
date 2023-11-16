using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ExpControl : MonoBehaviour
{
    public TMP_Text levelUIText;
    public TMP_Text levelText;
    public TMP_Text expText;

    [SerializeField] //�ܺν�ũ��Ʈ���� ������ ���� ���ϰ� �ϴ� ����(insfactor������ ���ٰ���)
    private Slider expbar;

    public float maxExp = 3;  //Exp�� max�� 100���� ����
    public float curExp = 0; //Exp�� �ʱⰪ�� 0���� ����

    public int level = 1;

    void Start()
    {
        expbar.value = (float)curExp / (float)maxExp; // Exp�� ���� 0/100 ���� ����
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log($"GetKeyDown:{KeyCode.G}");
            curExp += 1;  
        }

        Handle();
    }
    public void Handle()
    {
        expbar.value = (float)curExp / (float)maxExp; //Handle�� �� 0/100

        if (expbar.value >= 1)
        {
            expbar.value = expbar.value - 1;
            level++;
            levelUIText.text = level.ToString();
            levelText.text = level.ToString();

            if (level <= 6)
            {
                maxExp = maxExp + 5;
            }
            else
                maxExp = maxExp + 6;
        }

        expText.text = curExp.ToString() + "/" + maxExp.ToString();
    }
}
