//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class FruitBowl : MonoBehaviour
//{
//    public FruitType fruitType; // �׸��� ����ִ� ���ķ� ����
//    private Y_TimebarController timebarController; // ���ķ� ������ �����ϴ� ��ũ��Ʈ
//    public Button sellButton; // �Ǹ� ��ư
//    public Text timeText; // �ð��� ǥ���� UI Text

//    private void Start()
//    {
//        timebarController = GetComponent<Y_TimebarController>();
//        timebarController.SetFruitType(fruitType);
//        sellButton.onClick.AddListener(SellFruit);
//    }

//    public void SellFruit()
//    {
//        // �Ǹ� �ý��� ����
//        Y_TimebarController timebar = GetComponent<Y_TimebarController>();

//        if (timebar.CanAccelerate())
//        {
//            // �Ǹ� ������ ���
//            // �Ǹ� ���� �߰� (��: ��� �߰�, ������ ���� ��ũ��Ʈ ������Ʈ)
//            DataManager.Instance.Deposit(earnedGold); // earnedGold�� �Ǹŷ� ���� ���

//            // ���ķ� �缳��
//            timebar.ResetProgressBar();
//        }
//    }
//}

