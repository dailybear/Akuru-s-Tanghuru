using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_FruitSpawn : MonoBehaviour
{
    FruitData fruitData;
    public static G_FruitSpawn instance;
    [SerializeField]
    private List<FruitData> fruitDatas = new List<FruitData>(); // ���� ����
    [SerializeField]
    private GameObject fruitPrefab;

    public Transform[] points; // ���� ����Ʈ
    Transform curSpawnPoint;
    FruitData selectedFruit;
    public Transform randomPoint;
    Vector3 position;
    private Sprite sprite;

    public List<FruitData> fruitList = new List<FruitData>(); // ���������� ������ �� ����Ʈ
    
    int maxNum = 8;


    private void Awake()
    {
        points = GameObject.Find("FruitSpawnPoint").GetComponentsInChildren<Transform>();
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnFruit());
    }

    public static G_FruitSpawn Instance
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

    // ������ ���� ������
    public void randomSelect()
    {
        int selection = 0;
        if (fruitList.Count < 9)
        {
            
            selection = Random.Range(0, fruitDatas.Count);
            selectedFruit = fruitDatas[selection];
            fruitList.Add(selectedFruit); // �������� ���õ� ������ fruitList�� �߰�
        }
    }



    public IEnumerator SpawnFruit()
    {
        if(fruitList.Count <= maxNum)
        { 
            curSpawnPoint = null;
            while (curSpawnPoint == null)
            {
                randomSelect();
                int randomFruit = Random.Range(0, fruitDatas.Count);
                int idx = Random.Range(0, points.Length); // ���� ��������Ʈ ��ġ�� ã�Ƽ�
                if (points[idx].GetComponent<FruitSpawnPoint>().IsPlaceable == true) // ���� ���� ��������Ʈ�� isplaceable�� true�̸� 
                {
                    yield return new WaitForSeconds(selectedFruit.None_time);
                    curSpawnPoint = points[idx]; // ���� ���� ����Ʈ�� 
                    position = curSpawnPoint.position;
                    var fruit = SpawnFunc((FruitType)randomFruit);
                    sprite = selectedFruit.FlowerSprite;
                    //Instantiate(selectedFruit, points[idx].position, points[idx].rotation);
                }
                else
                {
                    yield return null;
                }
   
            }   
        }
    }

    public B_FruitScript SpawnFunc(FruitType type)
    {
        var newFruit = Instantiate(fruitPrefab).GetComponent<B_FruitScript>();
        newFruit.FruitData = fruitDatas[(int)type];
        curSpawnPoint.GetComponent<FruitSpawnPoint>().IsPlaceable = false;
        curSpawnPoint = null;
        return newFruit;
    }

    void Update()
    {
        
    }
}