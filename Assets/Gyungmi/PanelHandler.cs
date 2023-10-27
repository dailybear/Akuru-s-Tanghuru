using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelHandler : MonoBehaviour
{
    void Start()
    {
        DOTween.Init();
        transform.localScale = Vector3.one * 0.1f;
        // ��ü ��Ȱ��ȭ
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);

        // DOTween �Լ��� ���ʴ�� ����
        var seq = DOTween.Sequence();

        // DOScale�� ù ��° �Ķ���ʹ� ��ǥ Scale ��, �� ��°�� �ð�
        seq.Append(transform.DOScale(1.1f, 0.2f));
        seq.Append(transform.DOScale(1f, 0.1f));

        seq.Play();
    }

    public void Hide()
    {
        var seq = DOTween.Sequence();

        transform.localScale = Vector3.one * 0.2f;

        seq.Append(transform.DOScale(1.1f, 0.1f));
        seq.Append(transform.DOScale(0.2f, 0.2f));

        // OnComplete�� seq �� ������ �ִϸ��̼��� �÷��̰� �Ϸ�Ǹ�
        // {} �ȿ� �ִ� �ڵ� ���� => �ݱ� �ִϸ��̼��� �Ϸ�� �� ��ü ��Ȱ��ȭ
        seq.Play().OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }

    void Update()
    {
        
    }
}
