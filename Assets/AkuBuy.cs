using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkuBuy : MonoBehaviour
{
    [SerializeField] float speed = 100;
    Vector2 originalPosition;
    Animator anim;

    private void Awake()
    {
        originalPosition = this.transform.localPosition;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        AkuBuyProcess();
        MoveToOrigin();
        AkuBuySuccess();
    }

    void AkuBuyProcess()
    {
        if (transform.position.y<0)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        //����簡 �����ϴ� ��ҿ� ���������� 
        if (transform.localPosition.y > 0)
        {
            //�̵� ���߱� 
            speed = 0;
            //�ִϸ��̼� ��ȯ
            anim.SetBool("buying", true);
            // ���� ����
            B_GameManager.Instance.isBuyReady = true;
        }
    }

    void AkuBuySuccess()
    {
        if (B_GameManager.Instance.buySuccess)
        {
            speed = 100;
            transform.Translate(Vector3.right * speed * Time.deltaTime);    
            anim.SetBool("buying", false);
        }
    }

    void MoveToOrigin()
    {
        // ����簡 ���Ÿ� �� �ϰ� �̵������� 
        //transform.localPosition = originalPosition;
       // speed = 100;
    }
}
