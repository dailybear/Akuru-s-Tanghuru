using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BackgroundPanelHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ��ü�� ��Ȱ��ȭ �մϴ�.
        gameObject.SetActive(false);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
            gameObject.SetActive(false);
    }
}
