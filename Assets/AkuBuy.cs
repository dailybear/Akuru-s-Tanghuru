using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkuBuy : MonoBehaviour
{
    [SerializeField] float speed = 100;
    Vector2 originalPosition;

    private void Awake()
    {
        originalPosition = this.transform.localPosition;
    }

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        AkuBuyProcess();
        MoveToOrigin();
    }

    void AkuBuyProcess()
    {
        //����簡 �����ϴ� ��ҿ� ���������� 
        if(transform.localPosition.y > -1.5)
        {
            //�̵� ���߱� 
            speed = 0;
            //�ִϸ��̼� ��ȯ
        }

    }

    void MoveToOrigin()
    {
        // ����簡 ���Ÿ� �� �ϰ� �̵������� 
        //transform.localPosition = originalPosition;
       // speed = 100;
    }
}
