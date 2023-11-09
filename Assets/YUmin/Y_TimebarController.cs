//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Y_TimebarController : MonoBehaviour
//{
//    public Slider progressBar; // ���α׷��� �� UI ���
//    public Button accelerateButton; // ���� ��ư UI ���
//    public Text timeText; // �ð��� ǥ���� UI Text

//    // �� ���ķ� ������ ��� �ð� �� ��Ÿ��
//    private Dictionary<FruitType, float> preparationTimes = new Dictionary<FruitType, float>
//    {
//        { FruitType.StrawberryTang, 21.0f },
//        { FruitType.GrapeTang, 21.0f },
//        { FruitType.OrangeTang, 30.0f },
//        { FruitType.PineappleTang, 30.0f },
//        { FruitType.BlueberryTang, 30.0f }
//    };

//    private float currentTime; // ���� ���� �ð�
//    private bool isAccelerated = false; // ���� ����
//    private float lastRealTime; // ������ ���� �ð�

//    public float CurrentTime
//    {
//        get { return currentTime; }
//    }

//    private void Start()
//    {
//        // �ʱ� ��� �ð� ����
//        currentFruitType = FruitType.StrawberryTang; // ó���� �������ķ�� ����
//        currentTime = preparationTimes[currentFruitType];
//        progressBar.maxValue = preparationTimes[currentFruitType];
//        progressBar.value = preparationTimes[currentFruitType];
//        progressBar.interactable = false;

//        accelerateButton.onClick.AddListener(AccelerateProgress);

//        lastRealTime = Time.realtimeSinceStartup;
//    }

//    private void Update()
//    {
//        if (isAccelerated)
//        {
//            float realTimeNow = Time.realtimeSinceStartup;
//            float deltaTime = realTimeNow - lastRealTime;
//            lastRealTime = realTimeNow;

//            currentTime -= deltaTime;
//            UpdateProgressBar();
//        }
//    }

//    private void UpdateProgressBar()
//    {
//        progressBar.value = currentTime;
//        timeText.text = Mathf.FloorToInt(currentTime) + "s";

//        if (currentTime <= 0)
//        {
//            Debug.Log("���ķ� ���� �Ϸ�");
//            ResetProgressBar();
//        }
//    }

//    private void ResetProgressBar()
//    {
//        currentTime = preparationTimes[currentFruitType];
//        progressBar.value = preparationTimes[currentFruitType];
//        isAccelerated = false;
//        progressBar.interactable = false;
//    }

//    private FruitType currentFruitType; // ���� ���õ� ���ķ� ����

//    public void SetFruitType(FruitType fruitType)
//    {
//        currentFruitType = fruitType;
//        currentTime = preparationTimes[currentFruitType];
//        progressBar.maxValue = preparationTimes[currentFruitType];
//        progressBar.value = preparationTimes[currentFruitType];
//    }

//    public void AccelerateProgress()
//    {
//        // ���� ��ư�� ���� �� ��Ÿ���� Ȯ��
//        if (CanAccelerate())
//        {
//            isAccelerated = true;
//            progressBar.interactable = true;
//        }
//    }

//    public bool CanAccelerate()
//    {
//        // ��Ÿ���� 0 ������ ��� ���� ����
//        return preparationTimes[currentFruitType] <= 0;
//    }
//}
