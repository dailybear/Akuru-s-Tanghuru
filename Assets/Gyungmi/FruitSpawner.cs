using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    // ���� ��������Ʈ�� ���� �迭
    public Transform[] points;

    // ���� ������
    // public GameObject strawberryPrefab;
    public GameObject[] fruits;
    private List<GameObject> gameObject = new List<GameObject>();

    // ���� ���� �ֱ�
    float createTime = 5f;
    // �ִ� ����
    int maxNum = 8;

    void Start()
    {
        points = GameObject.Find("FruitSpawnPoint").GetComponentsInChildren<Transform>();

        if (points.Length > 0)
        {
            StartCoroutine(this.SpawnFruit());
        }
    }

    IEnumerator SpawnFruit()
    {
        while (true)
        {
            int selection = Random.Range(0, fruits.Length); // ���� ������ ���� ����
            GameObject selectedFruit = fruits[selection];
            int fruitCount = (int)GameObject.FindGameObjectsWithTag("Fruit").Length;

            if (fruitCount < maxNum)
            {
                yield return new WaitForSeconds(createTime);

                int idx = Random.Range(1, points.Length);

                GameObject instance = Instantiate(selectedFruit, points[idx].position, points[idx].rotation);
                gameObject.Add(instance);
            }
            else
            {
                yield return null;
            }
        }

    }

    void Update()
    {

    }
}
