using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUIManager : MonoBehaviour
{
    System.Action _OnClickConformButton, _OnClickCancelButton;
    private static PopupUIManager _instance;
    public static PopupUIManager Instance { get { return _instance; } }
    public GameObject container;

    private void Awake()
    {
        container.SetActive(false);
        DontDestroyOnLoad(this);
        _instance = this;
    }

    public void open(System.Action OnClickConformButton, System.Action OnClickCancelButton)
    {
        container.SetActive(true);
        _OnClickConformButton = OnClickConformButton;
        _OnClickCancelButton = OnClickCancelButton;
    }

    public void Close()
    {
        container.SetActive(false);
    }

    public void OnClickConformButton()
    {
        if(_OnClickConformButton != null)
        {
            Debug.Log("Ȯ�ι�ư");
            _OnClickConformButton();
        }
    }
    public void OnClickCancelButton()
    {
        if(_OnClickCancelButton != null)
        {
            Debug.Log("��ҹ�ư");
            _OnClickCancelButton();
        }
        Close();
    }


    void Update()
    {
        
    }
}
