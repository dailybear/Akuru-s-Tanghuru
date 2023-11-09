//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class FruitSeller : MonoBehaviour
//{
//    public List<FruitBowl> fruitBowls; // ��� �׸��� ����
//    public DataManager dataManager; // ������ ���� ��ũ��Ʈ
//    public Text earnedGoldText; // �Ǹŷ� ���� ��� ǥ�ø� ���� UI Text

//    private void Update()
//    {
//        // �Ǹŷ� ���� ��带 UI�� ǥ��
//        int earnedGold = CalculateEarnedGold();
//        earnedGoldText.text = "Earned Gold: " + earnedGold;
//    }

//    private int CalculateEarnedGold()
//    {
//        int earnedGold = 0;

//        foreach (FruitBowl bowl in fruitBowls)
//        {
//            Y_TimebarController timebar = bowl.GetComponent<Y_TimebarController>();

//            if (timebar.CanAccelerate())
//            {
//                // �Ǹ� ������ ���, ��� ��� �߰� (��: �� ���ķ� �� ���� ���)
//                int price = CalculatePrice(bowl.fruitType);
//                earnedGold += price;
//            }
//        }

//        return earnedGold;
//    }

//    private int CalculatePrice(FruitType fruitType)
//    {
//        // �� ���ķ� �� ���� ��� (��: �������ķ�� 10���, û�������ķ�� 15��� ��)
//        switch (fruitType)
//        {
//            case FruitType.StrawberryTang:
//                return 20;
//            case FruitType.GrapeTang:
//                return 20;
//            // �ٸ� ���ķ��� ���� ��� �߰�
//            default:
//                return 5; // �⺻ ����
//        }
//    }
//}
