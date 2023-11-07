using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;

    // ���� ������ �� ���� ���� ���� (���, ���ķ� ���� ��)
    public static int currentGold = 0; // currentGold�� static���� ����

    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataManager>();
            }
            return instance;
        }
    }

    // ��� ����, ���ķ� ���� ������Ʈ ���� ���� �Լ���
    public void Deposit(int amount)
    {
        currentGold += amount;
    }
}


