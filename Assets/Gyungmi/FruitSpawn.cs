using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitSpawn : MonoBehaviour
{
    public FruitData[] fruitData;
    [SerializeField]
    private int MaxFruitsType;
    [SerializeField]
    private GameObject[] fruits;

    void Start()
    {
        
    }

    void Update()
    {
        for (int i = 0; i < fruits.Length; i++)
        {
            int randomFruits = Random.Range(0,fruitData.Length);
            if (fruits[i].GetComponent<FruitGrow>().isGrowing == false &&
                fruits[i].GetComponent<FruitGrow>().isGathering == true) //���� ���� �ƴϰ� ä���� �Ǿ��� �� ���Ӱ� �Ҵ�
            {
                fruits[i].GetComponent<FruitGrow>().SetUp(fruitData[randomFruits]);
            }
        }
    }
}
