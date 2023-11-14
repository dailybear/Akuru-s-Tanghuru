using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouletteController : MonoBehaviour
{
    public Transform arrow; // ȭ��ǥ ������Ʈ
    public Transform rouletteWheel; // �귿�� ����
    public float initialRotationSpeed = 100.0f; // �ʱ� �귿 ȸ�� �ӵ�
    public float finalRotationSpeed = 20.0f; // ���� �귿 ȸ�� �ӵ� (���� ��)
    public float decelerationTime = 1.0f; // ������ ���۵Ǵ� �ð� (5�� ��ü �ð� ��)
    public float minRotationSpeed = 80.0f; // �ּ� �귿 ȸ�� �ӵ�
    public float maxRotationSpeed = 120.0f; // �ִ� �귿 ȸ�� �ӵ�
    public Sprite spinningSprite; // ȸ�� ���� ���� �̹���
    public Sprite idleSprite; // �⺻ ������ �̹���

    private bool isSpinning = false; // �귿 ȸ�� ������ ����
    private float rotationSpeed; // ���� �귿 ȸ�� �ӵ�
    private string[] items = { "����X1", "����X10", "����X20", "����X30", "���X40", "���X1", "���X2", "����X1" };
    private float spinTime = 0.0f; // �귿 ȸ�� �ð� ����
    private float targetAngle; // �귿�� ���߰� �� ����

    void Start()
    {
        // ��ư Ŭ�� �� SpinRoulette �Լ� ����
        GetComponent<Button>().onClick.AddListener(SpinRoulette);
        rotationSpeed = initialRotationSpeed;
        targetAngle = Random.Range(-360, 360);
    }

    void Update()
    {
        if (isSpinning)
        {
            float step = rotationSpeed * Time.deltaTime;
            rouletteWheel.Rotate(0, 0, -step);

            spinTime += Time.deltaTime;

            if (spinTime >= (5.0f - decelerationTime)) // ���� ���� �ð� ���
            {
                rotationSpeed = Mathf.Lerp(initialRotationSpeed, finalRotationSpeed, (spinTime - (5.0f - decelerationTime)) / decelerationTime); // ���� �ð��� ���� �ӵ� ����
            }

            if (spinTime >= 5.0f) // 5�ʿ� �����ϸ� ȸ���� ����ϴ�.
            {
                rotationSpeed = 0;
                isSpinning = false;
                CalculateResult();
            }
        }
    }

    public void SpinRoulette()
    {
        if (!isSpinning)
        {
            isSpinning = true;
            spinTime = 0.0f;

            // ������ ȸ�� �ӵ� ����
            rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);

            GetComponent<Image>().sprite = spinningSprite; // ��ư �̹����� ȸ�� �� �̹����� �����մϴ�.

            // ȭ��ǥ�� ȸ�� ������ �������� �귿�� ȸ�� ���� ����
            float arrowAngle = arrow.eulerAngles.z;
            rouletteWheel.rotation = Quaternion.Euler(0, 0, arrowAngle);

            // ������ ���� ���
            targetAngle = Random.Range(720, 1080); // ������ �� ���� �� ������ ���� (2���� ~ 3����)
            targetAngle += arrowAngle; // ȭ��ǥ ������ ���� ������ ���� ���� ����
        }
    }

    void CalculateResult()
    {
        // ������ ȸ�� ������ 0���� 360 ������ ��ȯ�Ͽ� ó��
        float wheelAngle = rouletteWheel.eulerAngles.z;
        wheelAngle = (wheelAngle + 360) % 360; // ���� ���� ó��

        float normalizedAngle = wheelAngle - (360 * Mathf.FloorToInt(wheelAngle / 360)); // 0������ 360�� ������ ������ ��ȯ

        // ���ϴ� ���� ���� ���� �ִ��� Ȯ��
        int index = Mathf.FloorToInt(normalizedAngle / 45);

        //Debug.Log("Index at 0 degree reference line: " + index);
        Debug.Log("Result: " + items[index]);

        GetComponent<Image>().sprite = idleSprite; // ��ư �̹����� �⺻ �̹����� �����մϴ�.
    }
}
