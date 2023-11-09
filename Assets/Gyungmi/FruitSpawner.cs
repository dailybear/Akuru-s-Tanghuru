using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public static FruitSpawner instance;
    // ���� ��������Ʈ�� ���� �迭
    public Transform[] points;

    public GameObject[] fruits;
    public List<GameObject> fruitsList = new List<GameObject>();

    // ���� ���� �ֱ�
    float createTime;
    // �ִ� ����
    int maxNum = 8;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        points = GameObject.Find("FruitSpawnPoint").GetComponentsInChildren<Transform>();
        
    }

    public static FruitSpawner Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }

    }

    void Start()
    {
        points = GameObject.Find("FruitSpawnPoint").GetComponentsInChildren<Transform>();

        
        if (points.Length > 0)
        {
            StartCoroutine(SpawnFruit());
        }
        
    }

    public void randomFruit()
    {
        int randomSelect = Random.Range(0, fruits.Length);
        GameObject selectedFruit = fruits[randomSelect];
        //createTime = 
    }

    
    public IEnumerator SpawnFruit()
    {
        int fruitCount = (int)GameObject.FindGameObjectsWithTag("Fruit").Length;
        while (fruitsList.Count <= maxNum)
        {
            fruitsList.Clear();
            int selection = Random.Range(0, fruits.Length); // ���� ������ ���� ����
            GameObject selectedFruit = fruits[selection];
            //int fruitCount = (int)GameObject.FindGameObjectsWithTag("Fruit").Length;
            createTime = 3f;

            if (fruitCount < maxNum)
            {
                
                yield return new WaitForSeconds(createTime);

                int idx = Random.Range(1, points.Length);

                GameObject fruit = Instantiate(selectedFruit, points[idx].position, points[idx].rotation);
                fruitsList.Add(fruit);
            }
            else
            {
                yield return null;
            }
        }
    }
    
    void Update()
    {
        /*
        if (points.Length > 0)
        {
            SpawnFruit();
        }
        */
    }
}
